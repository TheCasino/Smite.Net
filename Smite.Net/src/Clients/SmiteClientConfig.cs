namespace Smite.Net
{
    public struct SmiteClientConfig
    {
        public string DevKey { get; set; }
        public string AuthKey { get; set; }
        public bool AutomaticallyRecreateSessions { get; set; }

        public SmiteClientConfig(string devKey, string authKey, bool autoSessions = true)
        {
            DevKey = devKey;
            AuthKey = authKey;
            AutomaticallyRecreateSessions = autoSessions;
        }
    }
}
