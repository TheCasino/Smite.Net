using System;

namespace Smite.Net
{
    public sealed class God
    {
        private readonly GodModel _model;

        /// <summary>
        /// The God's id.
        /// </summary>
        public int Id => _model.Id;

        private Uri _cardArtUrl;

        /// <summary>
        /// The url for the God's card art.
        /// </summary>
        public Uri CardArtUrl => _cardArtUrl ?? (_cardArtUrl = new Uri(_model.godCard_URL));

        private Uri _iconArtUrl;

        /// <summary>
        /// The url for the God's icon art.
        /// </summary>
        public Uri IconArtUrl => _iconArtUrl ?? (_iconArtUrl = new Uri(_model.godIcon_URL));

        /// <summary>
        /// Whether the God is the most recent to be released or not.
        /// </summary>
        public bool IsLatestGod
        {
            get
            {
                switch(_model.LatestGod)
                {
                    case "y":
                        return true;

                    case "n":
                        return false;
                }

                throw new ArgumentException($"Unknown LastestGod type {_model.LatestGod}.");
            }
        }

        private Ability _first;

        /// <summary>
        /// The God's first ability.
        /// </summary>
        public Ability FirstAbility => _first ?? (_first = new Ability(_model.Ability_1));

        private Ability _second;

        /// <summary>
        /// The God's second ability.
        /// </summary>
        public Ability SecondAbility => _second ?? (_second = new Ability(_model.Ability_2));

        private Ability _third;

        /// <summary>
        /// The God's third ability.
        /// </summary>
        public Ability ThirdAbility => _third ?? (_third = new Ability(_model.Ability_3));

        private Ability _fourth;

        /// <summary>
        /// The God's ultimate ability.
        /// </summary>
        public Ability UltimateAbility => _fourth ?? (_fourth = new Ability(_model.Ability_4));

        private Ability _passive;

        /// <summary>
        /// The God's passive.
        /// </summary>
        public Ability Passive => _passive ?? (_passive = new Ability(_model.Ability_5));

        /// <summary>
        /// The God's base attack speed.
        /// </summary>
        public double AttackSpeed => _model.AttackSpeed;

        /// <summary>
        /// The attack speed gained per level.
        /// </summary>
        public double AttackSpeedPerLevel => _model.AttackSpeedPerLevel;

        /// <summary>
        /// The cons of the God.
        /// </summary>
        public string Cons => _model.Cons;

        /// <summary>
        /// The pros of the God.
        /// </summary>
        public string Pros => _model.Pros;

        /// <summary>
        /// The HP5 gained per level.
        /// </summary>
        public double HP5PerLevel => _model.HP5PerLevel;

        /// <summary>
        /// The base health of the God.
        /// </summary>
        public int Health => _model.Health;

        /// <summary>
        /// The base HP5 of the God.
        /// </summary>
        public double HealthPerFive => _model.HealthPerFive;

        /// <summary>
        /// The health gained per level.
        /// </summary>
        public double HealthPerLevel => _model.HealthPerLevel;

        /// <summary>
        /// The God's lore.
        /// </summary>
        public string Lore => _model.Lore;

        /// <summary>
        /// The base magical protections of the God.
        /// </summary>
        public double MagicalProtections => _model.MagicProtection;

        /// <summary>
        /// The magical protections gained per level.
        /// </summary>
        public double MagicalProtectionsPerLevel => _model.MagicProtectionPerLevel;

        /// <summary>
        /// The base magical power of the God.
        /// </summary>
        public double MagicalPower => _model.MagicalPower;

        /// <summary>
        /// The magical power gained per level.
        /// </summary>
        public double MagicalPowerPerLevel => _model.MagicalPowerPerLevel;

        /// <summary>
        /// The MP5 gained per level.
        /// </summary>
        public double MP5PerLevel => _model.MP5PerLevel;

        /// <summary>
        /// The base mana of the God.
        /// </summary>
        public double Mana => _model.Mana;

        /// <summary>
        /// The base MP5 of the God.
        /// </summary>
        public double ManaPerFive => _model.ManaPerFive;

        /// <summary>
        /// The mana gained per level.
        /// </summary>
        public double ManaPerLevel => _model.ManaPerLevel;

        /// <summary>
        /// The God's name.
        /// </summary>
        public string Name => _model.Name;

        /// <summary>
        /// If the God is currently in the free rotation pool.
        /// </summary>
        public bool OnFreeRotation
        {
            get
            {
                switch(_model.OnFreeRotation)
                {
                    case "":
                        return false;

                    case "true":
                        return true;
                }

                throw new ArgumentException($"Unknown OnFreeRotation type {_model.OnFreeRotation}.");
            }
        }

        /// <summary>
        /// The God's pantheon.
        /// </summary>
        public Pantheon Pantheon
        {
            get
            {
                switch(_model.Pantheon)
                {
                    case "Norse":
                        return Pantheon.Norse;

                    case "Greek":
                        return Pantheon.Greek;

                    case "Roman":
                        return Pantheon.Roman;

                    case "Egyptian":
                        return Pantheon.Egyptian;

                    case "Japanese":
                        return Pantheon.Japanese;

                    case "Chinese":
                        return Pantheon.Chinese;

                    case "Voodoo":
                        return Pantheon.Voodoo;

                    case "Polynesian":
                        return Pantheon.Polynesian;

                    case "Arthurian":
                        return Pantheon.Arthurian;

                    case "Celtic":
                        return Pantheon.Celtic;

                    case "Hindu":
                        return Pantheon.Hindu;

                    case "Mayan":
                        return Pantheon.Mayan;

                    case "Slavic":
                        return Pantheon.Slavic;
                }

                throw new ArgumentException($"Unknown Pantheon {_model.Pantheon}.");
            }
        }

        /// <summary>
        /// The base physical power of the God.
        /// </summary>
        public double PhysicalPower => _model.PhysicalPower;

        /// <summary>
        /// The physical power gained per level.
        /// </summary>
        public double PhysicalPowerPerLevel => _model.PhysicalPowerPerLevel;

        /// <summary>
        /// The base physical protections of the God.
        /// </summary>
        public double PhysicalProtections => _model.PhysicalProtection;

        /// <summary>
        /// The physical protections gained per level.
        /// </summary>
        public double PhysicalProtectionsPerLevel => _model.PhysicalProtectionPerLevel;

        /// <summary>
        /// The God's role.
        /// </summary>
        public Role Role
        {
            get
            {
                switch(_model.Roles)
                {
                    case " Assassin":
                        return Role.Assassin;

                    case " Warrior":
                        return Role.Warrior;

                    case " Guardian":
                        return Role.Guardian;

                    case " Mage":
                        return Role.Mage;

                    case " Hunter":
                        return Role.Hunter;
                }

                throw new ArgumentException($"Unknown Roles type {_model.Roles}.");
            }
        }

        /// <summary>
        /// The base movement speed of the God.
        /// </summary>
        public double MovementSpeed => _model.Speed;

        /// <summary>
        /// The God's title.
        /// </summary>
        public string Title => _model.Title;

        /// <summary>
        /// The God's intended playstyle.
        /// </summary>
        public Playstyle Playstyle
        {
            get
            {
                switch(_model.Type)
                {
                    case " Magical":
                        return Playstyle.Magical;

                    case " Melee, Magical":
                        return Playstyle.MeleeMagical;

                    case " Melee, Physical":
                        return Playstyle.MeleePhysical;

                    case " Ranged":
                        return Playstyle.Ranged;

                    case " Ranged, Magical":
                        return Playstyle.RangedMagical;

                    case " Ranged, Physical":
                        return Playstyle.RangedPhysical;
                }

                throw new ArgumentException($"Unknown Playstyle Type {_model.Type}.");
            }
        }

        internal God(GodModel model)
        {
            _model = model;
        }
    }
}
