namespace Smite.Net
{
    public sealed class ItemStat : BaseEntity
    {
        public string Description { get; }
        public string Value { get; }

        internal ItemStat(SmiteClient client, string desc, string value) : base(client)
        {
            Description = desc;
            Value = value;
        }
    }
}
