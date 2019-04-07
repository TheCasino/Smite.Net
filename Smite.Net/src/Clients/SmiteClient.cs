using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Smite.Net
{
    /// <summary>
    /// A client with a valid session.
    /// </summary>
    public sealed partial class SmiteClient : BaseSmiteClient, IDisposable
    {
        public readonly RestClient _restClient;
        private readonly SmiteClientConfig _config;

        public SessionModel _currentSession;

        /// <summary>
        /// Whether the clients session is currently valid or not.
        /// </summary>
        public bool ValidSession
        {
            get
            {
                var invalidated = DateTimeOffset.ParseExact(_currentSession.timestamp,
                    "M/d/yyyy H:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal)
                    .AddMinutes(15);

                var now = DateTimeOffset.UtcNow;

                return invalidated - now < TimeSpan.FromMinutes(15);
            }
        }

        internal SmiteClient(RestClient rest, SmiteClientConfig config, SessionModel session)
        {
            _restClient = rest;
            _restClient.BaseClient = this;
            _config = config;
            _currentSession = session;
        }

        internal async Task SessionRecreationAsync()
        {
            while (true)
            {
                var time = DateTimeOffset.ParseExact(_currentSession.timestamp, 
                    "M/d/yyyy H:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

                var toWait = time.AddMinutes(14).AddSeconds(45) - DateTimeOffset.UtcNow;

                await Task.Delay(toWait).ConfigureAwait(false);

                await InternalSessionInvalidatedAsync();

                _currentSession = await _restClient
                    .GetAsync<SessionModel>(APIPlatform.PC, "createsession", null).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Initialises a session and creates a client.
        /// </summary>
        /// <param name="config">The config to use for the client.</param>
        /// <returns>A sessioned client.</returns>
        public static async Task<SmiteClient> CreateClientAsync(SmiteClientConfig config)
        {
            var client = await new SessionlessClient(config).CreateSessionAsync().ConfigureAwait(false);

            return client;
        }

        /// <summary>
        /// Initialises a session and creates a client.
        /// </summary>
        /// <param name="devId">Your dev id.</param>
        /// <param name="authKey">Your auth key.</param>
        /// <returns>A sessioned client.</returns>
        public static async Task<SmiteClient> CreateClientAsync(string devId, string authKey)
        {
            var config = new SmiteClientConfig(devId, authKey);

            var client = await CreateClientAsync(config).ConfigureAwait(false);

            return client;
        }

        private bool disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _restClient.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes of the client.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
