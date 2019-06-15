using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smite.Net
{
    public class RestClient : IDisposable
    {
        private readonly string _authKey;
        private readonly int _devId;
        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore;
        private readonly SmiteClient _smiteClient;

        private const string Format = "Json";
        private const string TimeFormat = "yyyyMMddHHmmss";

        public RestClient(int devId, string authKey, SmiteClient client)
        {
            _devId = devId;
            _authKey = authKey;

            _smiteClient = client;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _semaphore = new SemaphoreSlim(1);
        }

        public async Task<T> GetAsync<T>(APIPlatform platform, string methodName, 
            string sessionId, params object[] endPoints) where T : class
        {
            await _semaphore.WaitAsync();

            var time = DateTimeOffset.UtcNow;

            var url = UrlBuilder(platform, methodName, time, sessionId, endPoints);

            var sw = Stopwatch.StartNew();

            using var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            sw.Stop();

            //TODO error handling

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            await _smiteClient.InternalLogAsync($"GET/ {url} took {sw.ElapsedMilliseconds}ms").ConfigureAwait(false);

            Console.WriteLine(data);

            _semaphore.Release();

            if (typeof(T) == typeof(string))
                return data as T;

            return JsonConvert.DeserializeObject<T>(data);
        }

        private string UrlBuilder(APIPlatform platform, string methodName, 
            DateTimeOffset time, string sessionId, params object[] endpoints)
        {
            var sb = new StringBuilder();

            sb.Append(_platforms[platform]);
            sb.Append('/');
            sb.Append(methodName);
            sb.Append(Format);

            sb.Append('/');
            sb.Append(_devId);

            var signature = CreateSignature(methodName, time);

            sb.Append('/');
            sb.Append(signature);

            if(sessionId != null)
            {
                sb.Append('/');
                sb.Append(sessionId);
            }

            sb.Append('/');
            sb.Append(time.ToString(TimeFormat));

            foreach(var endpoint in endpoints)
            {
                if (endpoint is null)
                    continue;

                sb.Append('/');
                sb.Append(endpoint);
            }

            return sb.ToString();
        }

        private string CreateSignature(string methodName, DateTimeOffset time)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes($"{_devId}{methodName}{_authKey}{time.ToString(TimeFormat)}");

            bytes = md5.ComputeHash(bytes);

            var sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToString("x2").ToLower());

            return sb.ToString();
        }

        private static readonly Dictionary<APIPlatform, string> _platforms = new Dictionary<APIPlatform, string>
        {
            [APIPlatform.PC]   = APIDetails.PCBaseUrl,
            [APIPlatform.Xbox] = APIDetails.XboxBaseUrl,
            [APIPlatform.PS4]  = APIDetails.PS4BaseUrl
        };

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
