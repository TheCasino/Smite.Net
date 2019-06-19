using System;
using System.Threading.Tasks;

namespace Smite.Net
{
    public partial class SmiteClient
    {
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
        /// Event that fires whenever a new session is created.
        /// </summary>
        public event Func<DateTimeOffset, string, Task> SessionCreated;

        internal async Task InternalSessionCreatedAsync(DateTimeOffset createdAt, string sessionId)
        {
            if (SessionCreated != null)
                await SessionCreated(createdAt, sessionId);
        }
    }
}
