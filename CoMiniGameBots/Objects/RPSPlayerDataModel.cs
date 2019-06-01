using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Objects
{
    class RPSPlayerDataModel
    {
        class Player
        {
            public string Name { get; set; }
            public ulong DiscordID { get; set; }
            public Stats Stats { get; set; }
        }
        class Stats
        {
            public int NumberWins { get; set; }
            public int NumberLosses { get; set; }
            public int NumberRocks { get; set; }
            public int NumberPaper { get; set; }
            public int NumberScissors { get; set; }
        }
        
    }
}
