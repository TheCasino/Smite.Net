using System;
using System.Globalization;

namespace Smite.Net
{
    internal static class Utils
    {
        public static DateTimeOffset ParseTime(string @in)
            => DateTimeOffset.ParseExact(@in, "M/d/yyyy h:mm:ss tt", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.AssumeUniversal);
    }
}
