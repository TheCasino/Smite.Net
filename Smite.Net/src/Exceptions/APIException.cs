using System;

namespace Smite.Net
{
    public sealed class APIException : Exception
    {
        internal APIException(string msg) : base(msg)
        {
        }
    }
}
