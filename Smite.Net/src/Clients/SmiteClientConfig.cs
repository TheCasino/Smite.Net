namespace Smite.Net
{
    /// <summary>
    /// Config used for clients.
    /// </summary>
    public struct SmiteClientConfig
    {
        /// <summary>
        /// Your dev id.
        /// </summary>
        public string DevId { get; set; }

        /// <summary>
        /// Your auth key.
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// Whether to have the wrapper automatically recreate sessions for you.
        /// </summary>
        public bool AutomaticallyRecreateSessions { get; set; }

        /// <summary>
        /// Initialises a new client config.
        /// </summary>
        /// <param name="devId">Your dev id.</param>
        /// <param name="authKey">Your auth key.</param>
        /// <param name="autoSessions">Whether to have the wrapper automatically recreate sessions or not.</param>
        public SmiteClientConfig(string devId, string authKey, bool autoSessions = true)
        {
            DevId = devId;
            AuthKey = authKey;
            AutomaticallyRecreateSessions = autoSessions;
        }
    }
}
