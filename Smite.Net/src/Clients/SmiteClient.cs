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
        private readonly CancellationTokenSource _cts;
        public readonly RestClient _restClient; //public for testing

        public SessionModel _currentSession; //public for testing
        
        public SmiteClient(int devId, string authKey)
        {
            if (string.IsNullOrWhiteSpace(authKey))
                throw new ArgumentNullException(nameof(authKey));

            _cts = new CancellationTokenSource();
            _restClient = new RestClient(devId, authKey, this);
        }

        public event Func<string, Task> Log;

        internal async Task InternalLogAsync(string log)
        {
            if (Log != null)
                await Log(log);
        }

        public async Task StartAsync()
        {
            if (_currentSession != null)
                return;

            _currentSession = await _restClient
                .GetAsync<SessionModel>(APIPlatform.PC, "createsession", null)
                .ConfigureAwait(false);

            if (_currentSession.ret_msg != "Approved")
                throw new InvalidSessionException(_currentSession.ret_msg);

            _ = SessionTimerAsync();
        }

        internal async Task<T> GetAsync<T>(APIPlatform platform, string method, params object[] endpoints) where T : BaseModel
        {
            if (_currentSession is null)
                throw new InvalidSessionException();

            var res = await _restClient.GetAsync<T>(platform, method, _currentSession, endpoints).ConfigureAwait(false);

            if (res.ret_msg != null)
                throw new APIException(res.ret_msg);

            return res;
        }

        internal async Task<T[]> GetCollectionAsync<T>(APIPlatform platform, string method, params object[] endpoints) where T : BaseModel
        {
            if (_currentSession is null)
                throw new InvalidSessionException();

            var res = await _restClient.GetAsync<T[]>(platform, method, _currentSession, endpoints).ConfigureAwait(false);

            for(int i = 0; i < res.Length; i++)
            {
                var ret = res[i].ret_msg;

                if (ret != null)
                    throw new APIException(ret);
            }

            return res;
        }

        private async Task SessionTimerAsync()
        {
            while(true)
            {
                var time = Utils.ParseTime(_currentSession.timestamp);
                var toWait = time.AddMinutes(14).AddSeconds(45) - DateTimeOffset.UtcNow;

                try
                {
                    await Task.Delay(toWait, _cts.Token).ConfigureAwait(false);
                }
                catch(TaskCanceledException)
                {
                    break;
                }

                _currentSession = await _restClient
                    .GetAsync<SessionModel>(APIPlatform.PC, "createsession", null)
                    .ConfigureAwait(false);
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

            if(disposing)
            {
                _cts.Cancel(true);
                _cts.Dispose();
                _restClient.Dispose();
                _disposed = true;
            }
        }
    }
}
