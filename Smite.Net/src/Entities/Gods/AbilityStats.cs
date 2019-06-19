namespace Smite.Net
{
    public sealed class AbilityStats : BaseEntity
    {
        public string Description { get; internal set; }
        public string Value { get; internal set; }

        internal AbilityStats(SmiteClient client) : base(client)
        {
        }
    }
}
