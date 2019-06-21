namespace Smite.Net
{
    public sealed class PlayerCurrentStatus : BaseEntity
    {
        private readonly PlayerStatusModel _model;

        /// <summary>
        /// The players personal message,
        /// </summary>
        public string PersonalStatusMessage => _model.personal_status_message;

        /// <summary>
        /// The players match id.
        /// </summary>
        public int MatchId => _model.Match;

        /// <summary>
        /// The players queue id.
        /// </summary>
        public int MatchQueueId => _model.match_queue_id;

        /// <summary>
        /// The players current ingame status.
        /// </summary>
        public PlayerStatus Status => (PlayerStatus)_model.status;

        internal PlayerCurrentStatus(SmiteClient client, PlayerStatusModel model) : base(client)
        {
            _model = model;
        }
    }
}
