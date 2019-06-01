using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    class GameInprogressMessageEmbed
    {
        public static EmbedBuilder RPSGameStartedMessage(IUser user)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Game Already in progress!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            RPSBuilder.AddField(user.Username, "There's already a game in progress. Please wait for it to complete before trying again.", false);

            return RPSBuilder;
        }
    }
}
