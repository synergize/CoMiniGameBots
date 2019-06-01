using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
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
        private int MatchID = RPSGameDataClass.GameID;
        public RPSGameObject(RPSPlayerGameObject P1, RPSPlayerGameObject P2)
        {
            PlayerOne = P1;
            PlayerTwo = P2;
            RPSGameDataClass.GameID++;
        }
        public RPSGameObject()
        {
            RPSGameDataClass.GameID++;
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
    }
}
