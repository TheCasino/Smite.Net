using Smite.Net.ReadOnlyEntities;
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
    }
}
