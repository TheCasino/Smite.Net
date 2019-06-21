using Smite.Net.ReadOnlyEntities;
using System.Collections.Generic;
using System.Linq;

namespace Smite.Net
{
    public sealed class ItemDescription : BaseEntity
    {
        private readonly ItemDescriptionModel _model;

        /// <summary>
        /// The items description.
        /// </summary>
        public string Description => _model.Description;

        /// <summary>
        /// The items affect.
        /// </summary>
        public string Affect => _model.SecondaryDescription;

        private IReadOnlyCollection<ItemStat> _stats;

        /// <summary>
        /// The items stats.
        /// </summary>
        public IReadOnlyCollection<ItemStat> Stats
        {
            get
            {
                if (_stats == default)
                {
                    _stats = new ReadOnlyCollection<ItemStat>(
                        _model.Menuitems.Select(x => new ItemStat(Client, x.Description, x.Value)),
                        () => _model.Menuitems.Length);
                }

                return _stats;
            }
        }

        internal ItemDescription(SmiteClient client, ItemDescriptionModel model) : base(client)
        {
            _model = model;
        }
    }
}
