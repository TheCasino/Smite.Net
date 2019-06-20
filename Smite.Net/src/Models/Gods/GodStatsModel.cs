﻿namespace Smite.Net
{
    internal class GodStatsModel : BaseModel
    {
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int Losses { get; set; }
        public int MinionKills { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Worshippers { get; set; }
        public string god { get; set; }
        public int god_id { get; set; }
        public int player_id { get; set; }
    }
}
