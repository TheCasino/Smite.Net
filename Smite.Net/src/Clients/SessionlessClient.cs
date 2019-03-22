using System.Threading.Tasks;

namespace Smite.Net.Clients
{
    public sealed class SessionlessClient
    {
        private readonly string _devKey;

        public SessionlessClient(string devKey)
        {
            _devKey = devKey;
        }

        public static async Task<SmiteClient> CreateAsync(string devKey)
        {
            var authKey = "";

            return new SmiteClient(devKey, authKey);
        }

        public async Task<SmiteClient> CreateClientAsync()
        {
            var client = await CreateAsync(_devKey).ConfigureAwait(false);
            return client;
        }
    }
}
