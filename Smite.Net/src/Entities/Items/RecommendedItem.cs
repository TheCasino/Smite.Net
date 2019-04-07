using System;

namespace Smite.Net
{
    public sealed class RecommendedItem : IItem
    {
        private readonly RecommendedItemModel _model;

        /// <summary>
        /// The type category this item falls under.
        /// </summary>
        public ItemCategory Category
        {
            get
            {
                switch(_model.Category)
                {
                    case "Consumable":
                        return ItemCategory.Consumable;

                    case "Core":
                        return ItemCategory.Core;

                    case "Damage":
                        return ItemCategory.Damage;

                    case "Defensive":
                        return ItemCategory.Defensive;

                    case "Relic":
                        return ItemCategory.Relic;

                    case "Starter":
                        return ItemCategory.Starter;
                }

                throw new ArgumentException($"Unknown Category type {_model.Category}.");
            }
        }

        /// <summary>
        /// Gets whether this is a starter item or not.
        /// </summary>
        public bool IsStarterItem => Category == ItemCategory.Starter;

        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name => _model.Item;

        /// <summary>
        /// The role of the item.
        /// </summary>
        public ItemRole Role
        {
            get
            {
                switch(_model.Role)
                {
                    case "Adventures":
                        return ItemRole.Adventures;

                    case "Arena":
                        return ItemRole.Arena;

                    case "Standard":
                        return ItemRole.Standard;

                    case "Tutorial":
                        return ItemRole.Tutorial;
                }

                throw new ArgumentException($"Unknown Role type {_model.Role}.");
            }
        }

        /// <summary>
        /// The id of the category.
        /// </summary>
        public int CategoryId => _model.category_value_id;

        /// <summary>
        /// The God's id.
        /// </summary>
        public int GodId => _model.god_id;

        /// <summary>
        /// The God's name.
        /// </summary>
        public string GodName => _model.god_name;

        /// <summary>
        /// The id of the items icon.
        /// </summary>
        public int IconId => _model.icon_id;

        /// <summary>
        /// The id of the item.
        /// </summary>
        public int Id => _model.item_id;

        /// <summary>
        /// The id of the role.
        /// </summary>
        public int RoleId => _model.role_value_id;

        internal RecommendedItem(RecommendedItemModel model)
        {
            _model = model;
        }
    }
}
