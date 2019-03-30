using System;
using System.Threading.Tasks;

namespace Smite.Net
{
    public abstract class BaseSmiteClient : ISmiteClient
    {
        /// <summary>
        /// Pings the API.
        /// </summary>
        /// <returns>The response of the ping.</returns>
        public abstract Task<string> PingAsync();

        /// <summary>
        /// Fires when a new log message is raised.
        /// </summary>
        public Func<string, Task> Log;

        internal Task InternalLogAsync(string message)
        {
            return Log is null ? Task.CompletedTask : Log.Invoke(message);
        }
    }
}
