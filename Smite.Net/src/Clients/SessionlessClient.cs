using System.Threading.Tasks;

namespace Smite.Net
{
    /// <summary>
    /// A sessionless client.
    /// </summary>
    public sealed class SessionlessClient : ISmiteClient
    {
        private readonly SmiteClientConfig _config;
        private readonly RestClient _restClient;

        /// <summary>
        /// Initialises a new sessionless client.
        /// </summary>
        /// <param name="devId">Your dev id.</param>
        /// <param name="authKey">Your auth key.</param>
        public SessionlessClient(string devId, string authKey) : this(new SmiteClientConfig(devId, authKey))
        {
        }

        /// <summary>
        /// Initialises a new sessionless client.
        /// </summary>
        /// <param name="config">Your config.</param>
        public SessionlessClient(SmiteClientConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.DevId) || string.IsNullOrWhiteSpace(config.AuthKey))
                throw new System.ArgumentNullException("DevId and AuthKey must not be null or whitespace");

            _config = config;
            _restClient = new RestClient(_config);
        }

        /// <summary>
        /// Pings the API.
        /// </summary>
        /// <returns>The response of the ping.</returns>
        public async Task<string> PingAsync()
        {
            var response = await _restClient.PingAsync().ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <returns>A client that has a valid session.</returns>
        public async Task<SmiteClient> CreateSessionAsync()
        {
            var sessionModel = await _restClient
                .SendAsync<SessionModel>(Platform.PC, "createsession", null).ConfigureAwait(false);

            return new SmiteClient(_restClient, _config, sessionModel);
        }
    }
}
