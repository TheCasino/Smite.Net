using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smite.Net
{
    public sealed class Friend : BaseEntity
    {
        private readonly FriendModel _model;

        public string Name => _model.name;

        public int AccountId => _model.account_id;
        public int PlayerId => _model.player_id;

        private Uri _url;
        public Uri AvatarUrl => _url ?? (_url = new Uri(_model.avatar_url));

        internal Friend(SmiteClient client, FriendModel model) : base(client)
        {
            _model = model;
        }

        /// <summary>
        /// Gets this player.
        /// </summary>
        /// <param name="portal">The portal to use.</param>
        /// <returns>A collection of players pertaining to this player.</returns>
        public async Task<IReadOnlyCollection<Player>> GetPlayerAsync(Portal portal)
            => await Client.GetPlayerAsync(Name, portal).ConfigureAwait(false);

        /// <summary>
        /// Gets this players friends.
        /// </summary>
        /// <returns>A collection of friends.</returns>
        public async Task<IReadOnlyCollection<Friend>> GetFriendsAsync()
            => await Client.GetFriendsAsync(PlayerId).ConfigureAwait(false);
    }
}
