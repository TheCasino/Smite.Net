using System;
using System.Threading.Tasks;

namespace Smite.Net
{
    public sealed partial class SmiteClient
    {
        /// <summary>
        /// Fires when your current session has been invalidated.
        /// </summary>
        public Func<Task> SessionInvalidated;

        internal Task InternalSessionInvalidatedAsync()
        {
            return SessionInvalidated is null ? Task.CompletedTask : SessionInvalidated.Invoke();
        }

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
