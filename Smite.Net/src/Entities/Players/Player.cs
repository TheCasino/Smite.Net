using System;

namespace Smite.Net
{
    public sealed class Player
    {
        private readonly PlayerModel _model;

        /// <summary>
        /// The merged players.
        /// </summary>
        public string MergedPlayers => _model.MergedPlayers;

        /// <summary>
        /// The players name,
        /// </summary>
        public string Name => _model.Name;

        /// <summary>
        /// The players status message.
        /// </summary>
        public string StatusMessage => _model.Personal_Status_Message;

        /// <summary>
        /// The players region.
        /// </summary>
        public string Region => _model.Region;

        /// <summary>
        /// The players clan name.
        /// </summary>
        public string ClanName => _model.Team_Name;

        /// <summary>
        /// The players Hirez Gamertag.
        /// </summary>
        public string HirezGamertag => _model.hz_gamer_tag;

        /// <summary>
        /// The players Hirez name.
        /// </summary>
        public string HirezPlayerName => _model.hz_player_name;

        /// <summary>
        /// The players active id.
        /// </summary>
        public int ActiveId => _model.ActivePlayerId;

        /// <summary>
        /// The players id.
        /// </summary>
        public int Id => _model.Id;

        /// <summary>
        /// The total number of games this player has left.
        /// </summary>
        public int Leaves => _model.Leaves;

        /// <summary>
        /// The players level.
        /// </summary>
        public int Level => _model.Level;

        /// <summary>
        /// The total number of losses this player has.
        /// </summary>
        public int Losses => _model.Losses;

        /// <summary>
        /// The mastery levvel of this player.
        /// </summary>
        public int MasteryLevel => _model.MasteryLevel;

        /// <summary>
        /// The players clan's id.
        /// </summary>
        public int ClanId => _model.TeamId;

        /// <summary>
        /// The number of achievements this player has unlocked.
        /// </summary>
        public int AchievementCount => _model.Total_Achievements;

        /// <summary>
        /// The total number of worshippers this player has.
        /// </summary>
        public int TotalWorshipperCount => _model.Total_Worshippers;

        /// <summary>
        /// The total number of wins this player has.
        /// </summary>
        public int Wins => _model.Wins;

        /// <summary>
        /// The total number of hours this player has played.
        /// </summary>
        public int HoursPlayed => _model.HoursPlayed;

        /// <summary>
        /// This players ranked conquest MMR.
        /// </summary>
        public double RankedConquestMMR => _model.Rank_Stat_Conquest;

        /// <summary>
        /// This players ranked conquest console MMR.
        /// </summary>
        public double ConsoleRankedConquestMMR => _model.Rank_Stat_Conquest_Controller;

        /// <summary>
        /// This players duel MMR.
        /// </summary>
        public double DuelMMR => _model.Rank_Stat_Duel;

        /// <summary>
        /// This players console duel MMR.
        /// </summary>
        public double ConsoleDuelMMR => _model.Rank_Stat_Duel_Controller;


        /// <summary>
        /// This players ranked joust MMR.
        /// </summary>
        public double RankedJoustMMR => _model.Rank_Stat_Joust;

        /// <summary>
        /// This players console ranked joust MMR.
        /// </summary>
        public double ConsoleRankedJoustMMR => _model.Rank_Stat_Joust_Controller;

        /// <summary>
        /// This players conquest rank.
        /// </summary>
        public Rank ConquestRank => (Rank)_model.Tier_Conquest;

        /// <summary>
        /// This players duel rank.
        /// </summary>
        public Rank DuelRank => (Rank)_model.Tier_Duel;

        /// <summary>
        /// This players joust rank.
        /// </summary>
        public Rank JoustRank => (Rank)_model.Tier_Joust;

        private Uri _avatarUrl;
        /// <summary>
        /// The avatar url of the player.
        /// </summary>
        public Uri AvatarUrl => _avatarUrl 
            ?? (string.IsNullOrEmpty(_model.Avatar_URL) ? null : _avatarUrl = new Uri(_model.Avatar_URL));

        private DateTimeOffset? _createdAt;
        /// <summary>
        /// When this players account was created.
        /// </summary>
        public DateTimeOffset CreatedAt
        {
            get
            {
                _createdAt ??= Utils.ParseTime(_model.Created_Datetime);

                return _createdAt.Value;
            }
        }

        private DateTimeOffset? _lastLogin;
        /// <summary>
        /// When the player last logged in.
        /// </summary>
        public DateTimeOffset LastLogin
        {
            get
            {
                _lastLogin ??= Utils.ParseTime(_model.Last_Login_Datetime);

                return _lastLogin.Value;
            }
        }

        private PlayerRankedStats _conquest;
        /// <summary>
        /// The players ranked conquest stats.
        /// </summary>
        public PlayerRankedStats RankedConquestStats => _conquest 
            ?? (_conquest = new PlayerRankedStats(_model.RankedConquest));

        private PlayerRankedStats _conquestController;
        /// <summary>
        /// The players console ranked conquest stats.
        /// </summary>
        public PlayerRankedStats ConsoleRankedConquestStats => _conquestController 
            ?? (_conquestController = new PlayerRankedStats(_model.RankedConquestController));

        private PlayerRankedStats _duel;
        /// <summary>
        /// The players duel stats.
        /// </summary>
        public PlayerRankedStats DuelStats => _duel ?? (_duel = new PlayerRankedStats(_model.RankedDuel));

        private PlayerRankedStats _duelController;
        /// <summary>
        /// The players console duel stats.
        /// </summary>
        public PlayerRankedStats ConsoleDuelStats => _duelController 
            ?? (_duelController = new PlayerRankedStats(_model.RankedDuelController));

        private PlayerRankedStats _rankedJoust;
        /// <summary>
        /// The players ranked joust stats.
        /// </summary>
        public PlayerRankedStats RankedJoustStats => _rankedJoust 
            ?? (_rankedJoust = new PlayerRankedStats(_model.RankedJoust));

        private PlayerRankedStats _joustController;
        /// <summary>
        /// The players ranked joust stats.
        /// </summary>
        public PlayerRankedStats ConsoleRankedJoustStats => _joustController 
            ?? (_joustController = new PlayerRankedStats(_model.RankedJoustController));

        internal Player(PlayerModel model)
        {
            _model = model;
        }
    }

    public sealed class PlayerRankedStats
    {
        private readonly RankedPlayerStatsModel _model;

        /// <summary>
        /// The number of leaves this split.
        /// </summary>
        public int Leaves => _model.Leaves;

        /// <summary>
        /// The number of losses this split.
        /// </summary>
        public int Losses => _model.Losses;

        /// <summary>
        /// The current amount of TP.
        /// </summary>
        public int TP => _model.Points;

        /// <summary>
        /// Prvious leaderboard position.
        /// </summary>
        public int PreviousRank => _model.PrevRank;

        /// <summary>
        /// Current leaderboard position.
        /// </summary>
        public int CurrentRank => _model.Rank;

        /// <summary>
        /// Current season.
        /// </summary>
        public int Season => _model.Season;

        /// <summary>
        /// The trend in rank.
        /// </summary>
        public int Trend => _model.Trend;

        /// <summary>
        /// The number of wins this split.
        /// </summary>
        public int Wins => _model.Wins;

        /// <summary>
        /// What gamemode this is.
        /// </summary>
        public GameMode GameMode
        {
            get
            {
                switch(_model.Name)
                {
                    case "League":
                        return GameMode.ConquestRanked;

                    case "League Controller":
                        return GameMode.ConquestRankedController;

                    case "Duel":
                        return GameMode.Duel;

                    case "Duel Controller":
                        return GameMode.DuelController;

                    case "Joust":
                        return GameMode.JoustRanked;

                    case "Joust Controller":
                        return GameMode.JoustRankedController;

                    default:
                        throw new ArgumentOutOfRangeException($"Unknown Name type {_model.Name}", nameof(_model.Name));
                }
            }
        }

        /// <summary>
        /// The players MMR for this gamemode.
        /// </summary>
        public double MMR => _model.Rank_Stat;

        /// <summary>
        /// The players id.
        /// </summary>
        public int? PlayerId => _model.player_id;

        internal PlayerRankedStats(RankedPlayerStatsModel model)
        {
            _model = model;
        }
    }
}
