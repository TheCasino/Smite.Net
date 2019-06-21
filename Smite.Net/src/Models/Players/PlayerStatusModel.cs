namespace Smite.Net
{
    internal class PlayerStatusModel : BaseModel
    {
        public int Match { get; set; }
        public int match_queue_id { get; set; }
        public string personal_status_message { get; set; }
        public int status { get; set; }
        public string status_string { get; set; }
    }
}
