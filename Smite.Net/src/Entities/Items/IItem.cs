namespace Smite.Net
{
    public interface IItem
    {
        /// <summary>
        /// The id of the items icon.
        /// </summary>
        int IconId { get; }

        /// <summary>
        /// The id of them item.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Whether or not this item is a starter item.
        /// </summary>
        bool IsStarterItem { get; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        string Name { get; }
    }
}
