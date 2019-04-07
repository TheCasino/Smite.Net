namespace Smite.Net
{
    public sealed class ItemStat
    {
        public string Description { get; }
        public string Value { get; }

        internal ItemStat(string desc, string value)
        {
            Description = desc;
            Value = value;
        }
    }
}
