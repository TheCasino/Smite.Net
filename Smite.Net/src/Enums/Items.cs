namespace Smite.Net
{
    public enum ItemCategory
    {
        Consumable,
        Core,
        Damage,
        Defensive,
        Relic,
        Starter
    }

    public enum ItemRole
    {
        Adventures,
        Arena,
        Standard,
        Tutorial
    }

    public enum ClassAvailability
    {
        Empty           = 1,
        NoRestrictions  = 2,
        Assassin        = 4,
        Hunter          = 8,
        Mage            = 16,
        Guardian        = 32,
        Warrior         = 64
    }

    public enum ItemType
    {
        Active,
        Consumable,
        Item
    }
}
