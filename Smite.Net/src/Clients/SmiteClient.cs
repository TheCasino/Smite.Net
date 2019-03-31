using System;
using System.Globalization;
using System.Threading;
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

        private readonly Timer _sessionTimer;

        /// <summary>
        /// Whether the clients session is currently valid or not.
        /// </summary>
        public bool ValidSession
        {
            get
            {
                var invalidated = DateTimeOffset.Parse(_currentSession.timestamp, 
                    CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).AddMinutes(15);

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

            var time = DateTime.Parse(_currentSession.timestamp,
                    CultureInfo.InvariantCulture);


            var when = time.AddMinutes(14).AddSeconds(30) - DateTime.UtcNow;

            _sessionTimer = new Timer(_ => _ = SessionTimerCallbackAsync(), null, when, TimeSpan.FromMilliseconds(-1));
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

        private async Task SessionTimerCallbackAsync()
        {
            await InternalSessionInvalidatedAsync().ConfigureAwait(false);

            if (_config.AutomaticallyRecreateSessions)
            {
                var newSession = await _restClient
                    .GetAsync<SessionModel>(APIPlatform.PC, "createsession", null).ConfigureAwait(false);

                _currentSession = newSession;

                var time = DateTimeOffset.Parse(_currentSession.timestamp, 
                    CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

                var when = time.AddMinutes(14).AddSeconds(30) - DateTimeOffset.UtcNow;

                _sessionTimer.Change(when, TimeSpan.FromMilliseconds(-1));
            }
        }

        private bool disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _sessionTimer.Dispose();
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
