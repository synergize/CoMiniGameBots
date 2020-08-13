namespace CoMiniGameBots.Objects
{
    public class RpsPlayerStatsDataModel
    {

            public string Name { get; set; }
            public ulong DiscordId { get; set; }
            public PlayerStats Stats { get; set; }
        
        public class PlayerStats
        {
            public int NumberWins { get; set; }
            public int NumberLosses { get; set; }
            public int NumberRocks { get; set; }
            public int NumberPaper { get; set; }
            public int NumberScissors { get; set; }
            public int NumberDraws { get; set; }
        }
    }
}
