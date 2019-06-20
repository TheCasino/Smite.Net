using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smite.Net
{
    public sealed class GodStats : BaseEntity
    {
        private readonly GodStatsModel _model;

        /// <summary>
        /// The amount of assists with this god.
        /// </summary>
        public int Assists => _model.Assists;

        /// <summary>
        /// The amount of deaths with this god.
        /// </summary>
        public int Deaths => _model.Deaths;

        /// <summary>
        /// The amount of kills with this god.
        /// </summary>
        public int Kills => _model.Kills;

        /// <summary>
        /// The amount of losses with this god.
        /// </summary>
        public int Losses => _model.Losses;

        /// <summary>
        /// The amount of minion kills with this god.
        /// </summary>
        public int MinionKills => _model.MinionKills;

        /// <summary>
        /// The mastery level with this God.
        /// </summary>
        public int MasteryLevel => _model.Rank;

        /// <summary>
        /// The amount of wins with this god.
        /// </summary>
        public int Wins => _model.Wins;

        /// <summary>
        /// The amount of worshippers with this god.
        /// </summary>
        public int Worshippers => _model.Worshippers;
        
        /// <summary>
        /// The God's id.
        /// </summary>
        public int GodId => _model.god_id;

        /// <summary>
        /// The players id.
        /// </summary>
        public int PlayerId => _model.player_id;

        /// <summary>
        /// The God's name.
        /// </summary>
        public string GodName => _model.god;

        internal GodStats(SmiteClient client, GodStatsModel model) : base(client)
        {
            _model = model;
        }

        /// <summary>
        /// Gets the skins for this God.
        /// </summary>
        /// <param name="language">The language to use for the response.</param>
        /// <returns>A collection of skins.</returns>
        public async Task<IReadOnlyCollection<GodSkin>> GetSkinsAsync(Language language = Language.English)
            => await Client.GetSkinsAsync(GodId, language).ConfigureAwait(false);

        /// <summary>
        /// Gets the recommended items for this GOd.
        /// </summary>
        /// <param name="language">The language to use for the response.</param>
        /// <returns>A collection of recommended items.</returns>
        public async Task<IReadOnlyCollection<RecommendedItem>> GetRecommendedItemsAsync(Language language = Language.English)
            => await Client.GetRecommendedItemsAsync(GodId, language).ConfigureAwait(false);
    }
}
