using System.Threading.Tasks;

namespace Smite.Net
{
    public sealed class SessionlessClient : ISmiteClient
    {
        private readonly SmiteClientConfig _config;
        private readonly RestClient _restClient;

        public SessionlessClient(string devId, string authKey) : this(new SmiteClientConfig(devId, authKey))
        {
        }

        public SessionlessClient(SmiteClientConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.DevKey) || string.IsNullOrWhiteSpace(config.AuthKey))
                throw new System.ArgumentNullException("DevKey and AuthKey must not be null or whitespace");

            _config = config;
        }

        public async Task<string> PingAsync()
        {
            var response = await _restClient.PingAsync().ConfigureAwait(false);

            return response;
        }

        public async Task<SmiteClient> CreateSessionAsync()
        {
            var sessionModel = await _restClient
                .SendAsync<SessionModel>(Platform.PC, "createsession", null).ConfigureAwait(false);

            return new SmiteClient(_restClient, _config, sessionModel);
        }
    }
}
