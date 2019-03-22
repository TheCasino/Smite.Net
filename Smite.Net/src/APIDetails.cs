using System;

namespace Smite.Net
{
    public static class APIDetails
    {
        public const string PCBaseUrl = "http://api.smitegame.com/smiteapi.svc";
        public const string XboxBaseUrl = "http://api.xbox.smitegame.com/smiteapi.svc";
        public const string PS4BaseUrl = "http://api.ps4.smitegame.com/smiteapi.svc";

        public const int DefaultConcurrentSession = 50;
        public const int DefaultSessionsPerDay = 500;
        public static readonly TimeSpan DefaultSessionTimeLimt = TimeSpan.FromMinutes(15);
        public const int DefaultRequestsPerDayLimit = 7500;
    }
}
