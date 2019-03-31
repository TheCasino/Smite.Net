namespace Smite.Net
{
    public enum APIPlatform
    {
        PC,
        Xbox,
        PS4
    }

    public enum Status
    {
        Up,
        Down,
        Unknown
    }

    public enum Portal
    {
        HiRez   = 1,
        Steam   = 5,
        PS4     = 9,
        Xbox    = 10,
        Switch  = 22
    }

    public enum Language
    {
        English     = 1,
        German      = 2,
        French      = 3,
        Chinese     = 5,
        Spanish     = 7,
        Latam       = 9,
        Portuguese  = 10,
        Russian     = 11,
        Polish      = 12,
        Turkish     = 13
    }

    public enum AbilityType
    {
        Magical,
        MeleeMagical,
        MeleePhysical,
        Ranged,
        RangedMagical,
        RangedPhysical
    }

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
        Magical,
        MeleeMagical,
        MeleePhysical,
        Ranged,
        RangedMagical,
        RangedPhysical
    }

    public enum GameMode
    {
        ArenaQueue                  = 435,
        JoustQueued                 = 448,
        Conquest                    = 426,
        Assault                     = 445,
        Clash                       = 466,
        ConquestRanked              = 451,
        JoustRanked                 = 450,
        MOTD                        = 434,
        JoustChallenge              = 441,
        Siege                       = 459,
        Duel                        = 440,
        ArenaAIMedium               = 468,
        JoustAIMedium               = 456,
        ArenaTutorial               = 462,
        ArenaChallenge              = 438,
        ConquestChallenge           = 429,
        ConquestAIMedium            = 461,
        ArenaAIEasy                 = 457,
        ConquestAIEasy              = 476,
        JoustAIEasy                 = 474,
        ConquestRankedController    = 504,
        ArenaPracticeMedium         = 472,
        JoustRankedController       = 504,
        AssaultChallenge            = 446,
        AssaultAIMedium             = 454,
        JoustPracticeMedium         = 472,
        ArenaPracticeEasy           = 443,
        ClashChallenge              = 467,
        ClashAIMedium               = 469,
        AssaultAIEasy               = 481,
        SiegeChallenge              = 460,
        ConquestPracticeMedium      = 475,
        JoustPracticeEasy           = 464,
        DuelController              = 502,
        ConquestPracticeEasy        = 458,
        ClashAIEasy                 = 478,
        AssaultPracticeMedium       = 480,
        AssaultPracticeEasy         = 479,
        ClashPracticeMedium         = 477,
        ClashPracticeEasy           = 470,
        ClashTutorial               = 471,
        BasicTutorial               = 436
    }

    public enum Obtainability
    {
        Normal,
        Exclusive,
        Limited
    }
}
