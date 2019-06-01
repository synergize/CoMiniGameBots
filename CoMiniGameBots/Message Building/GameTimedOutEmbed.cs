using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    public static class GameTimedOutEmbed
    {
        public static EmbedBuilder RPSGameTimedOut()
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Game Timed Out";
            RPSBuilder.Description = "Game timed out. Response wasn't given in time.";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}
