namespace Smite.Net
{
    public enum Pantheon
    {
        Norse,
        Greek,
        Roman,
        Egyptian,
        Japanese,
        Chinese,
        Voodoo,
        Polynesian,
        Arthurian,
        Celtic,
        Hindu,
        Mayan,
        Slavic
    }

    public enum Role
    {
        Guardian,
        Warrior,
        Hunter,
        Mage,
        Assassin
    }

    public enum Playstyle
    {
        Magical         = 1,
        MeleeMagical    = 2,
        MeleePhysical   = 4,
        Ranged          = 8,
        RangedMagical   = 16,
        RangedPhysical  = 32
    }
}
