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
        private readonly SmiteClientConfig _config;
        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore;

        public BaseSmiteClient BaseClient;

        private const string Format = "Json";
        private const string TimeFormat = "yyyyMMddHHmmss";

        public RestClient(SmiteClientConfig config, BaseSmiteClient baseClient)
        {
            _config = config;

            BaseClient = baseClient;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _semaphore = new SemaphoreSlim(1);
        }

        public async Task<T> GetAsync<T>(APIPlatform platform, string methodName, 
            SessionModel session, params object[] endPoints)
        {
            await _semaphore.WaitAsync();

            var time = DateTimeOffset.UtcNow;

            var url = UrlBuilder(platform, methodName, time, session, endPoints);

            var sw = Stopwatch.StartNew();

            using var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            sw.Stop();

            //TODO error handling

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            await BaseClient.InternalLogAsync($"GET/ {url} took {sw.ElapsedMilliseconds}ms").ConfigureAwait(false);

            Console.WriteLine(data);

            _semaphore.Release();

            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<string> JsonlessMethodAsync(string methodName)
        {
            await _semaphore.WaitAsync();

            var url = string.Concat(_platforms[APIPlatform.PC], $"/{methodName}", Format);

            using var response = await _httpClient.GetAsync(url).ConfigureAwait(false); 

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _semaphore.Release();

            return data;
        }

        private string UrlBuilder(APIPlatform platform, string methodName, 
            DateTimeOffset time, SessionModel session, params object[] endpoints)
        {
            var sb = new StringBuilder();

            sb.Append(_platforms[platform]);
            sb.Append('/');
            sb.Append(methodName);
            sb.Append(Format);

            sb.Append('/');
            sb.Append(_config.DevId);

            var signature = CreateSignature(_config.DevId, methodName, _config.AuthKey, time);

            sb.Append('/');
            sb.Append(signature);

            if(!(session is null))
            {
                sb.Append('/');
                sb.Append(session.session_id);
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

        private static string CreateSignature(string devKey, string methodName, string authKey, DateTimeOffset time)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes($"{devKey}{methodName}{authKey}{time.ToString(TimeFormat)}");

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
