using System.Threading.Tasks;

namespace Smite.Net
{
    internal class RestClient
    {
        private readonly SmiteClientConfig _config;
        private readonly SmiteClient _client;

        public RestClient(SmiteClient client)
        {
            _client = client;
            _config = client.Config;
        }

        public async Task<T> SendAsync<T>()
        {
            return default;
        }
    }
}
