using System;
using System.Threading;
using System.Threading.Tasks;

namespace Smite.Net
{
    /// <summary>
    /// The client that's used to interact with the API.
    /// </summary>
    public sealed partial class SmiteClient : IDisposable
    {
        private string _sessionId;
        private readonly CancellationTokenSource _cts;
        public readonly RestClient _restClient; //public for testing

        public SessionModel _currentSession; //public for testing

        /// <summary>
        /// The current sessions id.
        /// </summary>
        public string SessionId => _sessionId ?? _currentSession.session_id;

        /// <summary>
        /// When the current session was created.
        /// </summary>
        public DateTimeOffset? SessionCreated => _currentSession is null 
            ? (DateTimeOffset?)null : Utils.ParseTime(_currentSession.timestamp);

        /// <summary>
        /// Creates a new client without a session.
        /// </summary>
        /// <param name="devId">Your dev id.</param>
        /// <param name="authKey">Your auth key.</param>
        public SmiteClient(int devId, string authKey) : this(devId, authKey, null)
        {
        }

        /// <summary>
        /// Creates a new client with the specified session.
        /// </summary>
        /// <param name="devId">Your dev id.</param>
        /// <param name="authKey">Your auth key.</param>
        /// <param name="sessionId">Your session id.</param>
        public SmiteClient(int devId, string authKey, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(authKey))
                throw new ArgumentNullException(nameof(authKey));

            _cts = new CancellationTokenSource();
            _restClient = new RestClient(devId, authKey, this);
            _sessionId = sessionId;
        }


        /// <summary>
        /// Event that fires whenever a new log is raised.
        /// </summary>
        public event Func<string, Task> Log;

        internal async Task InternalLogAsync(string log)
        {
            if (Log != null)
                await Log(log);
        }

        /// <summary>
        /// Starts the clients auto-session recreation.
        /// </summary>
        /// <param name="revalidateAfter">When to revalidate a session that was passed on creation.</param>
        /// <returns>An awaitable <see cref="Task"/></returns>
        public async Task StartAsync(TimeSpan? revalidateAfter = null)
        {
            if (_currentSession != null)
                return;

            if (_sessionId != null)
            {
                if (revalidateAfter is null)
                    throw new ArgumentNullException(nameof(revalidateAfter),
                        "When passing a session on creation this parameter needs to specified as to when the session expires");

                var test = await TestSessionAsync();

                if (test.IndexOf("Invalid") != -1)
                    throw new InvalidSessionException(test);

                _ = SessionTimerAsync(revalidateAfter.Value);
            }
            else
            {
                _currentSession = await _restClient
                    .GetAsync<SessionModel>(APIPlatform.PC, "createsession", null)
                    .ConfigureAwait(false);

                if (_currentSession.ret_msg != "Approved")
                    throw new InvalidSessionException(_currentSession.ret_msg);

                _ = SessionTimerAsync(null);
            }
        }

        internal async Task<T> GetAsync<T>(APIPlatform platform, string method, params object[] endpoints) where T : BaseModel
        {
            if (_currentSession is null)
                throw new InvalidSessionException();

            var res = await _restClient.GetAsync<T>(platform, method, SessionId, endpoints)
                .ConfigureAwait(false);

            if (res.ret_msg != null)
                throw new APIException(res.ret_msg);

            return res;
        }

        internal async Task<T[]> GetCollectionAsync<T>(APIPlatform platform, string method, params object[] endpoints) where T : BaseModel
        {
            if (_currentSession is null)
                throw new InvalidSessionException();

            var res = await _restClient.GetAsync<T[]>(platform, method, SessionId, endpoints)
                .ConfigureAwait(false);

            for (int i = 0; i < res.Length; i++)
            {
                var ret = res[i].ret_msg;

                if (ret != null)
                    throw new APIException(ret);
            }

            return res;
        }

        private async Task SessionTimerAsync(TimeSpan? toWait = null)
        {
            while (true)
            {
                if (toWait is null)
                {
                    var time = Utils.ParseTime(_currentSession.timestamp);
                    toWait = time.AddMinutes(14).AddSeconds(45) - DateTimeOffset.UtcNow;
                }

                try
                {
                    await Task.Delay(toWait.Value, _cts.Token).ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                _currentSession = await _restClient
                    .GetAsync<SessionModel>(APIPlatform.PC, "createsession", null)
                    .ConfigureAwait(false);

                if (_sessionId != null)
                    _sessionId = null;
            }
        }

        private bool _disposed;

        /// <summary>
        /// Disposes of the client.
        /// </summary>
        public void Dispose()
            => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _cts.Cancel(true);
                _cts.Dispose();
                _restClient.Dispose();
                _disposed = true;
            }
        }
    }
}
