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
            var response = await _restClient
                .GetAsync<GodModel[]>(APIPlatform.PC, "getgods", _currentSession, (int)language)
                .ConfigureAwait(false);

            var gods = response.Select(x => new God(x));

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

            if (!(gamemode == GameMode.ConquestRanked || gamemode == GameMode.Duel || gamemode == GameMode.JoustRanked))
                throw new ArgumentOutOfRangeException(nameof(gamemode),
                    "GameMode must be either ConquestRanked, Duel, or JoustRanked.");

            var response = await _restClient
                .GetAsync<LeaderboardEntryModel[]>(APIPlatform.PC,
                    "getgodleaderboard", _currentSession, godId, (int)gamemode).ConfigureAwait(false);

            return new ReadOnlyCollection<LeaderboardEntry>(response.Select(x => new LeaderboardEntry(x)), 
                () => response.Length);
        }
    }
}
