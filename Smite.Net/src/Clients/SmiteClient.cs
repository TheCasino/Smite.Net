using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Smite.Net
{
    public sealed partial class SmiteClient : ISmiteClient
    {
        private readonly RestClient _restClient;
        private readonly SmiteClientConfig _config;

        private SessionModel _currentSession;

        private readonly Timer _sessionTimer;

        internal SmiteClient(RestClient rest, SmiteClientConfig config, SessionModel session)
        {
            _restClient = rest;
            _config = config;
            _currentSession = session;

            var time = DateTimeOffset.ParseExact(_currentSession.timestamp, "yyyyMMddHHmmss",
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

            var when = time - DateTimeOffset.UtcNow.AddSeconds(30);

            _sessionTimer = new Timer(_ => _ = SessionTimerAsync(), null, when, TimeSpan.FromMilliseconds(-1));
        }

        private async Task SessionTimerAsync()
        {
            await InternalSessionInvalidatedAsync().ConfigureAwait(false);

            if (_config.AutomaticallyRecreateSessions)
            {
                var newSession = await _restClient
                    .SendAsync<SessionModel>(Platform.PC, "createsession", null).ConfigureAwait(false);

                _currentSession = newSession;

                var time = DateTimeOffset.ParseExact(_currentSession.timestamp, "yyyyMMddHHmmss",
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

                var when = time - DateTimeOffset.UtcNow.AddSeconds(30);

                _sessionTimer.Change(when, TimeSpan.FromMilliseconds(-1));
            }
        }

        public async Task<string> PingAsync()
        {
            var response = await _restClient.PingAsync().ConfigureAwait(false);

            return response;
        }
    }
}
