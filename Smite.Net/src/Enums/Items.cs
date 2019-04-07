using System;

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

    [Flags]
    public enum ClassAvailability
    {
        Empty,
        NoRestrictions,
        Assassin,
        Hunter,
        Mage,
        Guardian,
        Warrior
    }

    public enum ItemType
    {
        Active,
        Consumable,
        Item
    }
}
