using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    public class PlayerNoActiveGamesEmbed
    {
        public static EmbedBuilder RPSPlayerNeeded(IUser user)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "You're not in an active game!";
            RPSBuilder.Description = $"{user.Username}, I was unable to locate an active game with you in it. Please challenge someone and try again.";
            RPSBuilder.WithColor(16580608);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}
