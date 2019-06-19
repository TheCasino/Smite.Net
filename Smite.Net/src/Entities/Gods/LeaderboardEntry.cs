namespace Smite.Net
{
    public sealed class LeaderboardEntry : BaseEntity
    {
        private readonly LeaderboardEntryModel _model;

        /// <summary>
        /// The God's id.
        /// </summary>
        public int GodId => _model.god_id;

        /// <summary>
        /// The number of wins this player has for this God.
        /// </summary>
        public int Wins => _model.wins;

        /// <summary>
        /// The number of losses this player has for this God.
        /// </summary>
        public int Losses => _model.losses;

        /// <summary>
        /// The players name.
        /// </summary>
        public string PlayerName => _model.player_name;

        /// <summary>
        /// The players id.
        /// </summary>
        public int PlayerId => _model.player_id;

        /// <summary>
        /// The players elo on this God.
        /// </summary>
        public double PlayerRanking => _model.player_ranking;

        /// <summary>
        /// The players position on the leaderboard.
        /// </summary>
        public int Rank => _model.rank;

        internal LeaderboardEntry(SmiteClient client, LeaderboardEntryModel model) : base(client)
        {
            _model = model;
        }
    }
}
