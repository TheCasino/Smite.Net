using Smite.Net.ReadOnlyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smite.Net
{
    public sealed partial class SmiteClient
    {
        /// <summary>
        /// Gets all the God's currently in the game.
        /// </summary>
        /// <param name="language">The language for the response to use.</param>
        /// <returns>A collection of God's</returns>
        public async Task<IReadOnlyCollection<God>> GetGodsAsync(Language language = Language.English)
        {
            var response = await GetCollectionAsync<GodModel>(APIPlatform.PC, "getgods", (int)language)
                .ConfigureAwait(false);

            var gods = response.Select(x => new God(this, x));

            return new ReadOnlyCollection<God>(gods, () => response.Length);
        }

        /// <summary>
        /// Gets the leaderboard for the specified God.
        /// </summary>
        /// <param name="god">The God that you want the leaderboard for.</param>
        /// <param name="gamemode">The GameMode that you want.</param>
        /// <returns>A collection of LeaderboardEntry's.</returns>
        public async Task<IReadOnlyCollection<LeaderboardEntry>> GetLeaderboardAsync(God god, GameMode gamemode)
        {
            if (god is null)
                throw new ArgumentNullException(nameof(god));

            var entries = await GetLeaderboardAsync(god.Id, gamemode).ConfigureAwait(false);

            return entries;
        }

        /// <summary>
        /// Gets the leaderboard for the specified God id.
        /// </summary>
        /// <param name="godId">The id of the God that you want the leaderboard for.</param>
        /// <param name="gamemode">The GameMode that you want.</param>
        /// <returns>A collection of LeaderboardEntry's.</returns>
        public async Task<IReadOnlyCollection<LeaderboardEntry>> GetLeaderboardAsync(int godId, GameMode gamemode)
        {
            if (godId <= 0)
                throw new ArgumentOutOfRangeException(nameof(godId));

            if (!(gamemode == GameMode.ConquestRanked || gamemode == GameMode.Duel
                || gamemode == GameMode.JoustRanked))
                throw new ArgumentOutOfRangeException(nameof(gamemode),
                    "GameMode must be either ConquestRanked, Duel, or JoustRanked.");

            var response = await GetCollectionAsync<LeaderboardEntryModel>(APIPlatform.PC,
                    "getgodleaderboard", godId, (int)gamemode).ConfigureAwait(false);

            return new ReadOnlyCollection<LeaderboardEntry>(response.Select(x => new LeaderboardEntry(this, x)),
                () => response.Length);
        }

        /// <summary>
        /// Gets the skins for the specified God.
        /// </summary>
        /// <param name="god">The God you want to fetch the skins for.</param>
        /// <param name="language">The language to use.</param>
        /// <returns>A collection of skins.</returns>
        public async Task<IReadOnlyCollection<GodSkin>> GetSkinsAsync(God god, Language language = Language.English)
        {
            if (god is null)
                throw new ArgumentNullException(nameof(god));

            var entries = await GetSkinsAsync(god.Id, language).ConfigureAwait(false);

            return entries;
        }

        /// <summary>
        /// Gets the skins for ths specified God id.
        /// </summary>
        /// <param name="godId">The id of the God you want to get the skins for.</param>
        /// <param name="language">The language to use.</param>
        /// <returns>A collection of skins.</returns>
        public async Task<IReadOnlyCollection<GodSkin>> GetSkinsAsync(int godId, Language language = Language.English)
        {
            if (godId <= 0)
                throw new ArgumentOutOfRangeException(nameof(godId));

            var response = await GetCollectionAsync<GodSkinModel>(APIPlatform.PC,
                "getgodskins", godId, (int)language)
                .ConfigureAwait(false);

            return new ReadOnlyCollection<GodSkin>(response.Select(x => new GodSkin(this, x)), () => response.Length);
        }

        /// <summary>
        /// Gets the recommended items for this God.
        /// </summary>
        /// <param name="god">The God you want to fetch the items for.</param>
        /// <param name="language">The language to use.</param>
        /// <returns>A collection of recommended items.</returns>
        public async Task<IReadOnlyCollection<RecommendedItem>> GetRecommendedItemsAsync(God god,
            Language language = Language.English)
        {
            if (god is null)
                throw new ArgumentNullException(nameof(god));

            var items = await GetRecommendedItemsAsync(god.Id, language).ConfigureAwait(false);

            return items;
        }

        /// <summary>
        /// Gets the recommended items for the specified id.
        /// </summary>
        /// <param name="godId">The id of the God you want to fetch items for.</param>
        /// <param name="language">The language to use.</param>
        /// <returns>A collection of recommended items.</returns>
        public async Task<IReadOnlyCollection<RecommendedItem>> GetRecommendedItemsAsync(int godId,
            Language language = Language.English)
        {
            if (godId <= 0)
                throw new ArgumentOutOfRangeException(nameof(godId));

            var response = await GetCollectionAsync<RecommendedItemModel>(APIPlatform.PC,
                    "getgodrecommendeditems", godId, (int)language)
                .ConfigureAwait(false);

            return new ReadOnlyCollection<RecommendedItem>(
                response.Select(x => new RecommendedItem(this, x)), () => response.Length);
        }

        /// <summary>
        /// Gets all the items in the game.
        /// </summary>
        /// <param name="language">The language to use.</param>
        /// <returns>A collection of items.</returns>
        public async Task<IReadOnlyCollection<Item>> GetItemsAsync(Language language = Language.English)
        {
            var resp = await GetCollectionAsync<ItemModel>(APIPlatform.PC, "getitems", (int)language)
                .ConfigureAwait(false);

            return new ReadOnlyCollection<Item>(
                resp.Select(x => new Item(this, x)), () => resp.Length);
        }
    }
}
