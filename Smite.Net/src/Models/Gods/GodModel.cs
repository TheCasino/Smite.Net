namespace Smite.Net
{
    internal class GodModel : BaseModel
    {
        public string Ability1 { get; set; }
        public string Ability2 { get; set; }
        public string Ability3 { get; set; }
        public string Ability4 { get; set; }
        public string Ability5 { get; set; }

        public int AbilityId1 { get; set; }
        public int AbilityId2 { get; set; }
        public int AbilityId3 { get; set; }
        public int AbilityId4 { get; set; }
        public int AbilityId5 { get; set; }

        public AbilityModel Ability_1 { get; set; }
        public AbilityModel Ability_2 { get; set; }
        public AbilityModel Ability_3 { get; set; }
        public AbilityModel Ability_4 { get; set; }
        public AbilityModel Ability_5 { get; set; }

        public double AttackSpeed { get; set; }
        public double AttackSpeedPerLevel { get; set; }

        public string Cons { get; set; }

        public double HP5PerLevel { get; set; }

        public int Health { get; set; }
        public double HealthPerFive { get; set; }
        public double HealthPerLevel { get; set; }

        public string Lore { get; set; }
        
        public double MagicProtection { get; set; }
        public double MagicProtectionPerLevel { get; set; }
        public double MagicalPower { get; set; }
        public double MagicalPowerPerLevel { get; set; }

        public double MP5PerLevel { get; set; }
        public double Mana { get; set; }
        public double ManaPerFive { get; set; }
        public double ManaPerLevel { get; set; }

        public string Name { get; set; }
        public string OnFreeRotation { get; set; }
        public string Pantheon { get; set; }

        public double PhysicalPower { get; set; }
        public double PhysicalPowerPerLevel { get; set; }
        public double PhysicalProtection { get; set; }
        public double PhysicalProtectionPerLevel { get; set; }

        public string Pros { get; set; }
        public string Roles { get; set; }

        public double Speed { get; set; }

        public string Title { get; set; }
        public string Type { get; set; }

        public AbilityDescriptionModel AbilityDescription1 { get; set; }
        public AbilityDescriptionModel AbilityDescription2 { get; set; }
        public AbilityDescriptionModel AbilityDescription3 { get; set; }
        public AbilityDescriptionModel AbilityDescription4 { get; set; }
        public AbilityDescriptionModel AbilityDescription5 { get; set; }
        public AbilityDescriptionModel BasicAttack { get; set; }

        public string godAbility1_URL { get; set; }
        public string godAbility2_URL { get; set; }
        public string godAbility3_URL { get; set; }
        public string godAbility4_URL { get; set; }
        public string godAbility5_URL { get; set; }

        public string godCard_URL { get; set; } //
        public string godIcon_URL { get; set; } //
        public string LatestGod { get; set; } //

        public int id { get; set; } //
    }

    internal class AbilityModel
    {
        public AbilityDescriptionModel Description { get; set; }

        public int Id { get; set; }
        public string Summary { get; set; }
        public string URL { get; set; }
    }

    internal class AbilityDescriptionModel
    {
        public AbilityItemDescriptionModel itemDescription { get; set; }
    }

    internal class AbilityItemDescriptionModel
    {
        public string cooldown { get; set; }
        public string cost { get; set; }
        public string description { get; set; }

        public GodItemModel[] menuitems { get; set; }
        public GodItemModel[] rankitems { get; set; }

        public string secondaryDescription { get; set; }
    }

    internal class GodItemModel
    {
        public string description { get; set; }
        public string value { get; set; }
    }
}
