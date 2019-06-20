namespace Smite.Net
{
    public sealed class PlayerAccolades : BaseEntity
    {
        private readonly PlayerAccoladesModel _model;

        /// <summary>
        /// The total number of assisted kills.
        /// </summary>
        public int Assists => _model.AssistedKills;

        /// <summary>
        /// The total number of camps cleared.
        /// </summary>
        public int CampsCleared => _model.CampsCleared;

        /// <summary>
        /// The total number of deaths.
        /// </summary>
        public int Deaths => _model.Deaths;

        /// <summary>
        /// The total number of divine sprees.
        /// </summary>
        public int DivineSpree => _model.DivineSpree;

        /// <summary>
        /// The total number of double kills.
        /// </summary>
        public int DoubleKills => _model.DoubleKills;

        /// <summary>
        /// The total number of Fire Giant kills.
        /// </summary>
        public int FireGiantKills => _model.FireGiantKills;

        /// <summary>
        /// The total number of first bloods.
        /// </summary>
        public int FirstBloods => _model.FirstBloods;

        /// <summary>
        /// The total number of God-Like sprees.
        /// </summary>
        public int GodLikeSpree => _model.GodLikeSpree;

        /// <summary>
        /// The total number of Gold Fury kills.
        /// </summary>
        public int GoldFuryKills => _model.GoldFuryKills;

        /// <summary>
        /// The players id.
        /// </summary>
        public int PlayerId => _model.Id;

        /// <summary>
        /// The total number of immortal sprees.
        /// </summary>
        public int ImmortalSpree => _model.ImmortalSpree;

        /// <summary>
        /// The total number of killing sprees.
        /// </summary>
        public int KillingSpree => _model.KillingSpree;

        /// <summary>
        /// The total number of minion kills.
        /// </summary>
        public int MinionKills => _model.MinionKills;

        /// <summary>
        /// The players name.
        /// </summary>
        public string PlayerName => _model.Name;

        /// <summary>
        /// The total number of penta kills.
        /// </summary>
        public int PentaKills => _model.PentaKills;

        /// <summary>
        /// The total number of phoenix kills.
        /// </summary>
        public int PhoenixKills => _model.PhoenixKills;

        /// <summary>
        /// The total number of player kills.
        /// </summary>
        public int PlayerKills => _model.PlayerKills;

        /// <summary>
        /// The total number of quadra kills.
        /// </summary>
        public int QuadraKills => _model.QuadraKills;

        /// <summary>
        /// The total number of rampage sprees.
        /// </summary>
        public int RampageSpree => _model.RampageSpree;

        /// <summary>
        /// The total number of shutdowns.
        /// </summary>
        public int Shutdowns => _model.ShutdownSpree;

        /// <summary>
        /// The total number of siege juggernaut kills.
        /// </summary>
        public int SiegeJuggernautKills => _model.SiegeJuggernautKills;

        /// <summary>
        /// The total number of towers destroyed.
        /// </summary>
        public int TowerKills => _model.TowerKills;

        /// <summary>
        /// The total number of triple kills.
        /// </summary>
        public int TripleKills => _model.TripleKills;

        /// <summary>
        /// The total number of unstoppable sprees.
        /// </summary>
        public int UnstoppableSpree => _model.UnstoppableSpree;

        /// <summary>
        /// The total number of wild juggernaut kills.
        /// </summary>
        public int WildJuggernautKills => _model.WildJuggernautKills;

        internal PlayerAccolades(SmiteClient client, PlayerAccoladesModel model) : base(client)
        {
            _model = model;
        }
    }
}
