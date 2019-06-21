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

        /// <summary>
        /// Gets the current status of the specified player.
        /// </summary>
        /// <param name="player">The player that you want to know the status for.</param>
        /// <returns>A collection of player statuses.</returns>
        public static async Task<IReadOnlyCollection<PlayerCurrentStatus>> GetStatusAsync(this IPlayer player)
            => await player.Client.GetStatusAsync(player.PlayerId).ConfigureAwait(false);
    }
}
