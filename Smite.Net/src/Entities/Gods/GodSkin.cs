using System;

namespace Smite.Net
{
    public sealed class GodSkin : BaseEntity, IGod
    {
        private readonly GodSkinModel _model;

        private Uri _godIcon;

        /// <summary>
        /// The url for the art of the God's icon.
        /// </summary>
        public Uri GodIconUrl => _godIcon ?? (_godIcon = new Uri(_model.godIcon_URL));

        private Uri _godSkin;

        /// <summary>
        /// The url for the art of the skin.
        /// </summary>
        public Uri GodSkinUrl => string.IsNullOrWhiteSpace(_model.godSkin_URL)  //legendary and diamond skins don't have a url
            ? null 
            : _godSkin ?? (_godSkin = new Uri(_model.godSkin_URL));

        /// <summary>
        /// The God's id.
        /// </summary>
        public int GodId => _model.god_id;

        /// <summary>
        /// The God's name.
        /// </summary>
        public string GodName => _model.god_name;

        /// <summary>
        /// The obtainability of the skin.
        /// </summary>
        public Obtainability Obtainability
        {
            get
            {
                switch(_model.obtainability)
                {
                    case "Normal":
                        return Obtainability.Normal;

                    case "Exclusive":
                        return Obtainability.Exclusive;

                    case "Limited":
                        return Obtainability.Limited;
                }

                throw new ArgumentOutOfRangeException($"Unknown Obtainability type {_model.obtainability}.");
            }
        }

        /// <summary>
        /// The favour price of the skin.
        /// </summary>
        public int FavorPrice => _model.price_favor;

        /// <summary>
        /// The gem price of the skin.
        /// </summary>
        public int GemPrice => _model.price_gems;

        /// <summary>
        /// The skins first id.
        /// </summary>
        public int SkinId1 => _model.skin_id1;

        /// <summary>
        /// The skins second id.
        /// </summary>
        public int SkinId2 => _model.skin_id2;

        /// <summary>
        /// The skins name.
        /// </summary>
        public string SkinName => _model.skin_name;

        internal GodSkin(SmiteClient client, GodSkinModel model) : base(client)
        {
            _model = model;
        }

        public override string ToString()
            => SkinName;
    }
}
