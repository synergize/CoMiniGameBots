using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Objects
{
    class RPSGameObject
    {
        private RPSPlayerGameObject PlayerTwo;
        private RPSPlayerGameObject PlayerOne;
        private bool GameActive = false;
        private ISocketMessageChannel StartedChannel;
        private int MatchID = RPSGameDataClass.GameID;
        private string Winner = null;
        private DateTime TimeStarted;
        public RPSGameObject(RPSPlayerGameObject P1, RPSPlayerGameObject P2, ISocketMessageChannel channel)
        {
            PlayerOne = P1;
            PlayerTwo = P2;
            RPSGameDataClass.GameID++;
            GameActive = true;
            StartedChannel = channel;
            TimeStarted = DateTime.UtcNow;
        }
        public RPSGameObject(string win)
        {
            Winner = win;
        }
        public RPSPlayerGameObject POne
        {
            get { return PlayerOne; }
        }
        public RPSPlayerGameObject PTwo
        {
            get { return PlayerTwo; }
        }
        public bool IsActive
        {
            get { return GameActive; }
        }
        public int ID
        {
            get { return MatchID; }
        }
        public ISocketMessageChannel GameChannel
        {
            get { return StartedChannel; }
        }
        public DateTime StartTime
        {
            get { return TimeStarted; }
        }
    }
}
