namespace Smite.Net
{
    internal class PlayerModel : BaseModel
    {
        public int ActivePlayerId { get; set; }
        public string Avatar_URL { get; set; }
        public string Created_Datetime { get; set; }
        public int HoursPlayed { get; set; }
        public int Id { get; set; }
        public string Last_Login_Datetime { get; set; }
        public int Leaves { get; set; }
        public int Level { get; set; }
        public int Losses { get; set; }
        public int MasteryLevel { get; set; }
        public string MergedPlayers { get; set; }
        public string Name { get; set; }
        public string Personal_Status_Message { get; set; }
        public double Rank_Stat_Conquest { get; set; }
        public double Rank_Stat_Conquest_Controller { get; set; }
        public double Rank_Stat_Duel { get; set; }
        public double Rank_Stat_Duel_Controller { get; set; }
        public double Rank_Stat_Joust { get; set; }
        public double Rank_Stat_Joust_Controller { get; set; }
        public RankedPlayerStatsModel RankedConquest { get; set; }
        public RankedPlayerStatsModel RankedConquestController { get; set; }
        public RankedPlayerStatsModel RankedDuel { get; set; }
        public RankedPlayerStatsModel RankedDuelController { get; set; }
        public RankedPlayerStatsModel RankedJoust { get; set; }
        public RankedPlayerStatsModel RankedJoustController { get; set; }
        public string Region { get; set; }
        public int TeamId { get; set; }
        public string Team_Name { get; set; }
        public int Tier_Conquest { get; set; }
        public int Tier_Duel { get; set; }
        public int Tier_Joust { get; set; }
        public int Total_Achievements { get; set; }
        public int Total_Worshippers { get; set; }
        public int Wins { get; set; }
        public string hz_gamer_tag { get; set; }
        public string hz_player_name { get; set; }
    }

    internal class RankedPlayerStatsModel : BaseModel
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public double Rank_Stat { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public int? player_id { get; set; }
    }
}
