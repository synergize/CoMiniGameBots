using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoMiniGameBots.Objects
{
    public class RPSGameObject
    {
        private readonly RPSPlayerGameObject PlayerTwo;
        private readonly RPSPlayerGameObject PlayerOne;
        private bool GameActive = false;
        private readonly ISocketMessageChannel StartedChannel;
        private readonly bool Random;
        private readonly string Winner = null;
        private readonly string Loser = null;
        private readonly DateTime TimeStarted;
        public RPSGameObject(RPSPlayerGameObject P1, RPSPlayerGameObject P2, ISocketMessageChannel channel)
        {
            PlayerOne = P1;
            PlayerTwo = P2;
            GameActive = true;
            StartedChannel = channel;
            TimeStarted = DateTime.UtcNow;
            Random = false;
        }
        public RPSGameObject(RPSPlayerGameObject P1, RPSPlayerGameObject P2)
        {
            PlayerOne = P1;
            PlayerTwo = P2;
            GameActive = true;
            TimeStarted = DateTime.UtcNow;
            Random = true;
        }

        public RPSGameObject()
        {

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
            set => GameActive = value;
        }
        public ISocketMessageChannel GameChannel
        {
            get { return StartedChannel; }
        }
        public DateTime StartTime
        {
            get { return TimeStarted; }
        }
        public bool IsRandom
        {
            get { return Random; }
        }
    }
}
