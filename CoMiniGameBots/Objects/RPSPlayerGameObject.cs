using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Objects
{
    class RPSPlayerGameObject
    {
        private IUser GuildUser { get; set; }
        private string PlayerEntry = null;
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
    }
}
