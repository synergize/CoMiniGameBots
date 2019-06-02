using CoMiniGameBots.Objects;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class AnnouceWinnerMessageEmbed
    {
        public static EmbedBuilder RPSWinner(RPSPlayerGameObject winner)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "We've found a winner!";
            RPSBuilder.Description = $"{winner.User.Username} has won!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}
