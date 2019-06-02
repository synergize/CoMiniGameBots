using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    public static class WaitingPlayerMessageEmbed
    {
        public static EmbedBuilder WaitingForOpponent()
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Waiting for your opponent!";
            RPSBuilder.Description = "You've entered your entry before your opponent. When they send theirs I'll post the results in the discord where we started!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}
