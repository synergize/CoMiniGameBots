using CoMiniGameBots.Objects;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.MiniGames.RockPaperScissors
{
    static class RPSGameDataClass
    {
        private static RPSPlayerGameObject PlayerOne;
        private static RPSPlayerGameObject PlayerTwo;
        private static bool PlayBegin = false;
        private static bool PlayerWating = false;
        private static int ID = 0;
        private static List<RPSGameObject> ListOfGames = new List<RPSGameObject>();
        private static List<RPSPlayerGameObject> ListOfStats = new List<RPSPlayerGameObject>();

        public static RPSPlayerGameObject POne
        {
            get { return PlayerOne; }
            set { PlayerOne = value; }
        }
        public static RPSPlayerGameObject PTwo
        {
            get { return PlayerTwo ; }
            set { PlayerTwo = value; }
        }
        public static bool IsGameBegin
        {
            get { return PlayBegin; }
            set { PlayBegin = value; }
        }
        public static bool IsPlayerWaiting
        {
            get { return PlayerWating; }
            set { PlayerWating = value; }
        }
        public static List<RPSGameObject> ActiveGames
        {
            get { return ListOfGames; }
            set { ListOfGames = value; }
        }
        public static int GameID
        {
            get { return ID; }
            set { ID = value; }
        }
        public static List<RPSPlayerGameObject> PlayerStatsList
        {
            get { return ListOfStats; }
            set { ListOfStats = value; }
        }

    }
}
