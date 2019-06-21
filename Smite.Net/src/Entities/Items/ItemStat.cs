namespace Smite.Net
{
    public sealed class ItemStat : BaseEntity
    {
        /// <summary>
        /// The description of the stat.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The stats value.
        /// </summary>
        public string Value { get; }

        internal ItemStat(SmiteClient client, string desc, string value) : base(client)
        {
            Description = desc;
            Value = value;
        }
    }
}
