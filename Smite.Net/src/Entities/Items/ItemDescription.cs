using Smite.Net.ReadOnlyEntities;
using System.Collections.Generic;
using System.Linq;

namespace Smite.Net
{
    public sealed class ItemDescription
    {
        private readonly ItemDescriptionModel _model;

        public string Description => _model.Description;

        public string Affect => _model.SecondaryDescription;

        private IReadOnlyCollection<ItemStat> _stats;
        
        public IReadOnlyCollection<ItemStat> Stats
        {
            get
            {
                if(_stats == default)
                {
                    _stats = new ReadOnlyCollection<ItemStat>(
                        _model.Menuitems.Select(x => new ItemStat(x.Description, x.Value)), 
                        () => _model.Menuitems.Length);
                }

                return _stats;
            }
        }

        internal ItemDescription(ItemDescriptionModel model)
        {
            _model = model;
        }
    }
}
