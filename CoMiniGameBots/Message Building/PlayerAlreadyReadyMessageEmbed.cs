using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class PlayerAlreadyReadyMessageEmbed
    {
        public static EmbedBuilder RPSPlayerAlreadyReadyCheck(IUser user)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "You're already ready!";
            RPSBuilder.WithColor(16580608);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            RPSBuilder.AddField(user.Username, "You can't play against yourself, that's cheating!", false);

            return RPSBuilder;
        }
    }
}
