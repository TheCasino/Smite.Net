namespace Smite.Net
{
    internal class RecommendedItemModel : BaseModel
    {
        public string Category { get; set; }
        public string Item { get; set; }
        public string Role { get; set; }
        public int category_value_id { get; set; }
        public int god_id { get; set; }
        public string god_name { get; set; }
        public int icon_id { get; set; }
        public int item_id { get; set; }
        public int role_value_id { get; set; }
    }
}
