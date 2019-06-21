namespace Smite.Net
{
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// The client that was used to create the entity.
        /// </summary>
        public virtual SmiteClient Client { get; }

        public BaseEntity(SmiteClient client)
            => Client = client;
    }
}
