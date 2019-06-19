using Smite.Net.ReadOnlyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smite.Net
{
    // TODO /getplayeridbyportaluserid
    public partial class SmiteClient
    {
        /// <summary>
        /// Gets the player id corresponding to the specified name.
        /// </summary>
        /// <param name="name">The name of the player to search for.</param>
        /// <returns>A collection of found players.</returns>
        public async Task<IReadOnlyCollection<PlayerNameSearchResult>> GetPlayerIdFromNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var response = await GetCollectionAsync<PlayerIdByNameModel>(APIPlatform.PC, "getplayeridbyname", name)
                .ConfigureAwait(false);

            var results = response.Select(x => new PlayerNameSearchResult(this, x));

            return new ReadOnlyCollection<PlayerNameSearchResult>(results, () => response.Length);
        }

        /// <summary>
        /// Gets a player using their id.
        /// </summary>
        /// <param name="id">The id of the player.</param>
        /// <param name="portal">The portal to get this player from.</param>
        /// <returns>The player corresponding to the given id.</returns>
        public async Task<IReadOnlyCollection<Player>> GetPlayerAsync(string name, Portal? portal = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var response = await GetCollectionAsync<PlayerModel>(APIPlatform.PC, "getplayer", name, (int)portal)
                .ConfigureAwait(false);

            var result = response.Select(x => new Player(this, x));

            return new ReadOnlyCollection<Player>(result, () => response.Length);
        }

        /// <summary>
        /// Gets the player ids corresponding to the specified name.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="portal">The portal to use.</param>
        /// <returns>A collection of found players.</returns>
        public async Task<IReadOnlyCollection<PlayerNameSearchResult>> GetPlayerIdsFromGamertagAsync(string name, Portal portal)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var response = await GetCollectionAsync<PlayerIdByNameModel>(APIPlatform.PC, 
                "getplayeridsbygamertag", (int)portal, name)
                .ConfigureAwait(false);

            var results = response.Select(x => new PlayerNameSearchResult(this, x));

            return new ReadOnlyCollection<PlayerNameSearchResult>(results, () => response.Length);
        }
    }
}
