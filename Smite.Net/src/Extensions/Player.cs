using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smite.Net
{
    public static partial class Extensions
    {
        /// <summary>
        /// Gets this players friends.
        /// </summary>
        /// <param name="player">The player you want the friends for.</param>
        /// <returns>A collection of friends of this player.</returns>
        public static async Task<IReadOnlyCollection<Friend>> GetFriendsAsync(this IPlayer player)
            => await player.Client.GetFriendsAsync(player.PlayerId).ConfigureAwait(false);

        /// <summary>
        /// Gets this players God stats.
        /// </summary>
        /// <param name="player">The player that you want the God stats for.</param>
        /// <returns>A collection of God stats.</returns>
        public static async Task<IReadOnlyCollection<GodStats>> GetGodStatsAsync(this IPlayer player)
            => await player.Client.GetGodStatsAsync(player.PlayerId).ConfigureAwait(false);
    }
}
