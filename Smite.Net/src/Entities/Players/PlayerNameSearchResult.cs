using System;

namespace Smite.Net
{
    public sealed class PlayerNameSearchResult : BaseEntity
    {
        private readonly PlayerIdByNameModel _model;

        /// <summary>
        /// The id of the found player.
        /// </summary>
        public int PlayerId => _model.player_id;

        /// <summary>
        /// The id of the portal this player belongs to.
        /// </summary>
        public int PortalId => _model.portial_id;

        /// <summary>
        /// The portal this player belongs to.
        /// </summary>
        public Portal Portal
        {
            get
            {
                switch(_model.portal)
                {
                    case "Steam":
                        return Portal.Steam;

                    case "HiRez":
                        return Portal.HiRez;

                    case "Xbox":
                        return Portal.Xbox;

                    case "PS4":
                        return Portal.PS4;

                    default:
                        throw new ArgumentException($"Unknown Portal type", nameof(_model.portal));
                }
            }
        }

        internal PlayerNameSearchResult(SmiteClient client, PlayerIdByNameModel model) : base(client)
        {
            _model = model;
        }
    }
}
