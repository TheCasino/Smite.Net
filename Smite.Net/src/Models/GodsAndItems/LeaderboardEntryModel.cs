namespace Smite.Net
{
    internal class LeaderboardEntryModel : BaseModel
    {
        public int god_id { get; set; }
        public int losses { get; set; }
        public int player_id { get; set; }
        public string player_name { get; set; }
        public double player_ranking { get; set; }
        public int rank { get; set; }
        public int wins { get; set; }
    }
}
