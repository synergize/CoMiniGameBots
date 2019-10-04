using CoMiniGameBots.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Static_Data
{
    public static class RPSStaticGameLists
    {
        private static List<RPSGameObject> ListOfGames = new List<RPSGameObject>();
        private static List<RPSPlayerGameObject> ListOfStats = new List<RPSPlayerGameObject>();
        private static Queue<RPSPlayerGameObject> QueueOfGames = new Queue<RPSPlayerGameObject>();
        public static List<RPSPlayerGameObject> PlayerStatsList
        {
            get { return ListOfStats; }
            set { ListOfStats = value; }
        }
        public static List<RPSGameObject> ActiveGames
        {
            get { return ListOfGames; }
            set { ListOfGames = value; }
        }
        public static Queue<RPSPlayerGameObject> ActiveQueue
        {
            get { return QueueOfGames; }
            set { QueueOfGames = value; }
        }

        public static List<RPSGameObject> GetAllActiveGame()
        {
            return ActiveGames.FindAll(x => x.IsActive);
        }

    }
}
