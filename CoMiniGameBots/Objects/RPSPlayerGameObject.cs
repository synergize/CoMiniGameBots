using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Objects
{
    public class RPSPlayerGameObject
    {
        private IUser GuildUser { get; set; }
        private string PlayerEntry = null;
        private bool Winner = false;
        
        public RPSPlayerGameObject(IUser user, string entry = null)
        {
            GuildUser = user;
            PlayerEntry = entry;

        }
        public string Choice
        {
            get { return PlayerEntry; }
            set { PlayerEntry = value; }
        }
        public IUser User
        {
            get { return GuildUser; }
        }
        public bool IsWinner
        {
            get { return Winner; }
            set { Winner = value; }
        }
    }
}
