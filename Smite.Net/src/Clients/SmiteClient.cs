namespace Smite.Net
{
    public sealed class SmiteClient
    {
        public SmiteClientConfig Config { get; private set; }

        private readonly RestClient _client;

        public SmiteClient(string devKey, string authKey) : this(new SmiteClientConfig
        {
            DevKey = devKey,
            AuthKey = authKey
        })
        {
        }

        public SmiteClient(SmiteClientConfig config)
        {
            Config = config;
            _client = new RestClient(this);
        }
    }
}
