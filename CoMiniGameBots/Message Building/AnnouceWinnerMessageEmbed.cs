using CoMiniGameBots.Objects;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class AnnouceWinnerMessageEmbed
    {
        public static EmbedBuilder RPSWinner(RPSPlayerGameObject winner, RPSPlayerGameObject loser)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "We've found a winner!";
            RPSBuilder.AddField("Winner: ", $"{winner.User.Mention}", true);
            RPSBuilder.AddField("Loser: ", $"{loser.User.Mention}", true);
            RPSBuilder.AddField("Winner Choice: ", $"{winner.Choice.Remove(0, 1)}!", true);
            RPSBuilder.AddField("Loser Choice: ", $"{loser.Choice.Remove(0, 1)}!", true);
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}
