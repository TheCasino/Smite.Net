using System;

namespace Smite.Net
{
    public sealed class InvalidSessionException : Exception
    {
        internal InvalidSessionException() : base("A valid session has not been initialised. " +
            "Call the StartAsync method before attempting to make API calls.")
        {
        }

        internal InvalidSessionException(string msg) : base(msg)
        {
        }
    }
}
