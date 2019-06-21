using Smite.Net.ReadOnlyEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smite.Net
{
    public sealed class Ability : BaseEntity
    {
        private readonly AbilityModel _model;

        /// <summary>
        /// The id of the ability.
        /// </summary>
        public int Id => _model.Id;

        /// <summary>
        /// The abilities name.
        /// </summary>
        public string Name => _model.Summary;

        private Uri _url;
        /// <summary>
        /// The url of the abilities art.
        /// </summary>
        public Uri ArtUrl => _url ?? (_url = new Uri(_model.URL));

        /// <summary>
        /// The cooldown of the ability.
        /// </summary>
        public string Cooldown => _model.Description.itemDescription.cooldown;

        /// <summary>
        /// The mana cost of the ability.
        /// </summary>
        public string ManaCost => _model.Description.itemDescription.cost;

        /// <summary>
        /// The description of the ability.
        /// </summary>
        public string Description => _model.Description.itemDescription.description;

        public string SecondaryDescription => throw new NotImplementedException("I have no idea how to implement this properly");

        private IReadOnlyCollection<AbilityStats> _abilityStats;

        /// <summary>
        /// The stats of the ability.
        /// </summary>
        public IReadOnlyCollection<AbilityStats> Stats
        {
            get
            {
                if(_abilityStats == default)
                {
                    var stats = new List<GodItemModel>();
                    stats.AddRange(_model.Description.itemDescription.menuitems);
                    stats.AddRange(_model.Description.itemDescription.rankitems);

                    var abilities = stats.Select(x => new AbilityStats(Client)
                    {
                        Description = x.description,
                        Value = x.value
                    });

                    _abilityStats = new ReadOnlyCollection<AbilityStats>(abilities, () => stats.Count);
                }

                return _abilityStats;
            }
        }

        internal Ability(SmiteClient client, AbilityModel model) : base(client)
        {
            _model = model;
        }

        public override string ToString()
            => Name;
    }
}
