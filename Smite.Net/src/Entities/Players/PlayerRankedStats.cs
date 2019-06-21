using System;

namespace Smite.Net
{
    public sealed class PlayerRankedStats : BaseEntity, IPlayer
    {
        private readonly RankedPlayerStatsModel _model;

        /// <summary>
        /// The number of leaves this split.
        /// </summary>
        public int Leaves => _model.Leaves;

        /// <summary>
        /// The number of losses this split.
        /// </summary>
        public int Losses => _model.Losses;

        /// <summary>
        /// The current amount of TP.
        /// </summary>
        public int TP => _model.Points;

        /// <summary>
        /// Prvious leaderboard position.
        /// </summary>
        public int PreviousRank => _model.PrevRank;

        /// <summary>
        /// Current leaderboard position.
        /// </summary>
        public int CurrentRank => _model.Rank;

        /// <summary>
        /// Current season.
        /// </summary>
        public int Season => _model.Season;

        /// <summary>
        /// The trend in rank.
        /// </summary>
        public int Trend => _model.Trend;

        /// <summary>
        /// The number of wins this split.
        /// </summary>
        public int Wins => _model.Wins;

        /// <summary>
        /// What gamemode this is.
        /// </summary>
        public GameMode GameMode
        {
            get
            {
                switch (_model.Name)
                {
                    case "League":
                        return GameMode.ConquestRanked;

                    case "League Controller":
                        return GameMode.ConquestRankedController;

                    case "Duel":
                        return GameMode.Duel;

                    case "Duel Controller":
                        return GameMode.DuelController;

                    case "Joust":
                        return GameMode.JoustRanked;

                    case "Joust Controller":
                        return GameMode.JoustRankedController;

                    default:
                        throw new ArgumentOutOfRangeException($"Unknown Name type {_model.Name}", nameof(_model.Name));
                }
            }
        }

        /// <summary>
        /// The players MMR for this gamemode.
        /// </summary>
        public double MMR => _model.Rank_Stat;

        /// <summary>
        /// The players id.
        /// </summary>
        public int PlayerId => _model.player_id ?? 0;

        internal PlayerRankedStats(SmiteClient client, RankedPlayerStatsModel model) : base(client)
        {
            _model = model;
        }
    }
}
