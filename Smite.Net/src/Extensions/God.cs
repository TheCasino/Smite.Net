using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smite.Net
{
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the skins for this God.
        /// </summary>
        /// <param name="god">The God you want the skins for.</param>
        /// <param name="language">The language to use for the response.</param>
        /// <returns>A collections of skins for this God.</returns>
        public static async Task<IReadOnlyCollection<GodSkin>> GetSkinsAsync(this IGod god,
            Language language = Language.English)
            => await god.Client.GetSkinsAsync(god.GodId, language).ConfigureAwait(false);

        /// <summary>
        /// Gets the recommended items for this God.
        /// </summary>
        /// <param name="god">The God you want the skins for.</param>
        /// <param name="language">The language to use for the response.</param>
        /// <returns>A collection of recommended items.</returns>
        public static async Task<IReadOnlyCollection<RecommendedItem>> GetRecommendedItemsAsync(this IGod god,
            Language language = Language.English)
            => await god.Client.GetRecommendedItemsAsync(god.GodId, language).ConfigureAwait(false);

        /// <summary>
        /// Gets the leaderboard entries for this God.
        /// </summary>
        /// <param name="god">The God you want the skins for.</param>
        /// <param name="gameMode">The gamemode that you want the leaderboard for.</param>
        /// <returns>A collection of leaderboard entries.</returns>
        public static async Task<IReadOnlyCollection<LeaderboardEntry>> GetLeaderBoardAsync(this IGod god,
            GameMode gameMode)
            => await god.Client.GetLeaderboardAsync(god.GodId, gameMode).ConfigureAwait(false);
    }
}
