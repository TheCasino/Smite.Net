using System;

namespace Smite.Net
{
    public sealed class Item : IItem
    {
        private readonly ItemModel _model;

        /// <summary>
        /// The id of the icon.
        /// </summary>
        public int IconId => _model.IconId;

        /// <summary>
        /// The id of the item.
        /// </summary>
        public int Id => _model.ItemId;

        /// <summary>
        /// The id of the child item.
        /// </summary>
        public int ChildItemId => _model.ChildItemId;

        /// <summary>
        /// The items tier.
        /// </summary>
        public int Tier => _model.ItemTier;

        /// <summary>
        /// The items cost.
        /// </summary>
        public int Price => _model.Price;

        /// <summary>
        /// The id of the root item.
        /// </summary>
        public int RootItemId => _model.RootItemId;

        /// <summary>
        /// Whether or not the item is a starter item.
        /// </summary>
        public bool IsStarterItem => _model.StartingItem;

        /// <summary>
        /// The items name.
        /// </summary>
        public string Name => _model.DeviceName;

        /// <summary>
        /// A short description of the item.
        /// </summary>
        public string ShortDescription => _model.ShortDesc;

        /// <summary>
        /// What classes can use this item.
        /// </summary>
        public ClassAvailability Availability
        {
            get
            {
                var split = _model.RestrictedRoles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                ClassAvailability toReturn = default;

                for(int i = 0; i < split.Length; i++)
                {
                    switch(split[i])
                    {
                        case "":
                            toReturn |= ClassAvailability.Empty;
                            break;

                        case "assassin":
                            toReturn |= ClassAvailability.Assassin;
                            break;

                        case "hunter":
                            toReturn |= ClassAvailability.Hunter;
                            break;

                        case "mage":
                            toReturn |= ClassAvailability.Mage;
                            break;

                        case "warrior":
                            toReturn |= ClassAvailability.Warrior;
                            break;

                        case "guardian":
                            toReturn |= ClassAvailability.Guardian;
                            break;

                        case "no restrictions":
                            toReturn |= ClassAvailability.NoRestrictions;
                            break;

                        default:
                            throw new ArgumentException($"Unknown RestrictedRoles type {_model.RestrictedRoles}");
                    }
                }

                return toReturn;
            }
        }

        /// <summary>
        /// The type of the item.
        /// </summary>
        public ItemType Type
        {
            get
            {
                switch(_model.Type)
                {
                    case "Active":
                        return ItemType.Active;

                    case "Consumable":
                        return ItemType.Consumable;

                    case "Item":
                        return ItemType.Item;

                    default:
                        throw new ArgumentException($"Unknown Type type {_model.Type}");
                }
            }
        }

        private Uri _icon;

        /// <summary>
        /// The url of the items icon.
        /// </summary>
        public Uri ItemIconUrl => _icon ?? (_icon = new Uri(_model.itemIcon_URL));

        private ItemDescription _desc;

        /// <summary>
        /// The items description.
        /// </summary>
        public ItemDescription Description => _desc ?? (_desc = new ItemDescription(_model.ItemDescription));

        internal Item(ItemModel model)
        {
            _model = model;
        }
    }
}
