using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smite.Net
{
    internal class RestClient
    {
        private readonly SmiteClientConfig _config;
        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore;

        private const string Format = "Json";
        private const string TimeFormat = "yyyyMMddHHmmss";

        public RestClient(SmiteClientConfig config)
        {
            _config = config;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _semaphore = new SemaphoreSlim(1);
        }

        public async Task<T> SendAsync<T>(Platform platform, string methodName, 
            string sessionId, params string[] endPoints)
        {
            await _semaphore.WaitAsync();

            var time = DateTimeOffset.UtcNow;

            var url = UrlBuilder(platform, methodName, time, sessionId, endPoints);

            using var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            //TODO error handling

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _semaphore.Release();

            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<string> PingAsync()
        {
            await _semaphore.WaitAsync();

            var url = string.Concat(_platforms[Platform.PC], Format);

            using var response = await _httpClient.GetAsync(url).ConfigureAwait(false); 

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _semaphore.Release();

            return data;
        }

        private string UrlBuilder(Platform platform, string methodName, 
            DateTimeOffset time, string sessionId = null, params string[] endpoints)
        {
            var sb = new StringBuilder();

            sb.Append(_platforms[platform]);
            sb.Append('/');
            sb.Append(methodName);
            sb.Append(Format);

            sb.Append('/');
            sb.Append(_config.DevKey);

            var signature = CreateSignature(_config.DevKey, methodName, _config.AuthKey, time);

            sb.Append('/');
            sb.Append(signature);

            if(!string.IsNullOrWhiteSpace(sessionId))
            {
                sb.Append('/');
                sb.Append(sessionId);
            }

            sb.Append('/');
            sb.Append(time.ToString(TimeFormat));

            foreach(var endpoint in endpoints)
            {
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

            for (int i = 0; i <= bytes.Length; i++)
                sb.Append(bytes[i].ToString("x2").ToLower());

            return sb.ToString();
        }

        private static readonly Dictionary<Platform, string> _platforms = new Dictionary<Platform, string>
        {
            [Platform.PC]   = APIDetails.PCBaseUrl,
            [Platform.Xbox] = APIDetails.XboxBaseUrl,
            [Platform.PS4]  = APIDetails.PS4BaseUrl
        };
    }
}
