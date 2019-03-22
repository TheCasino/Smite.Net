namespace Smite.Net
{
    public struct SmiteClientConfig
    {
        public string DevKey { get; internal set; }
        public string AuthKey { get; internal set; }

        public SmiteClientConfig(string devKey, string authKey)
        {
            DevKey = devKey;
            AuthKey = authKey;
        }
    }
}
