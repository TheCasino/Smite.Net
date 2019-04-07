namespace Smite.Net
{
    internal class ItemModel : BaseModel
    {
        public int ChildItemId { get; set; }
        public string DeviceName { get; set; }
        public int IconId { get; set; }
        public ItemDescriptionModel ItemDescription { get; set; }
        public int ItemId { get; set; }
        public int ItemTier { get; set; }
        public int Price { get; set; }
        public string RestrictedRoles { get; set; }
        public int RootItemId { get; set; }
        public string ShortDesc { get; set; }
        public bool StartingItem { get; set; }
        public string Type { get; set; }
        public string itemIcon_URL { get; set; }
    }

    internal class ItemDescriptionModel
    {
        public string Description { get; set; }
        public MenuItemModel[] Menuitems { get; set; }
        public string SecondaryDescription { get; set; }
    }

    internal class MenuItemModel
    {
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
