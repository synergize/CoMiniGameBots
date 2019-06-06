using CoMiniGameBots.Objects;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class PlayerStatsMessageEmbed
    {
        public static EmbedBuilder RPSPlayerStats(RPSPlayerStatsDataModel stats, IUser user)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Rock Paper Scissors Stats!";
            RPSBuilder.Description = $"{user.Username}, {BuildCustomMessage(stats)}";
            RPSBuilder.AddField("Wins: ", $"{stats.Stats.NumberWins}", true);
            RPSBuilder.AddField("Losses: ", $"{stats.Stats.NumberLosses}", true);
            RPSBuilder.AddField("Draws: ", $"{stats.Stats.NumberDraws}", true);
            RPSBuilder.AddField("Rocks: ", $"{stats.Stats.NumberRocks}", true);
            RPSBuilder.AddField("Paper: ", $"{stats.Stats.NumberPaper}", true);
            RPSBuilder.AddField("Scissors: ", $"{stats.Stats.NumberScissors}", true);
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
        private static string BuildCustomMessage(RPSPlayerStatsDataModel stats)
        {
            var Rocks = stats.Stats.NumberRocks;
            var Paper = stats.Stats.NumberPaper;
            var Scissors = stats.Stats.NumberScissors;
            if (Rocks > Paper && Rocks > Scissors)
            {
                return "stop throwing so many rocks! You'll hurt your wenis.";
            }
            if (Paper > Rocks && Paper > Scissors)
            {
                return "you can make a lot of airplanes with that paper usage!";
            }
            if (Scissors > Paper && Scissors > Rocks)
            {
                return "sever run with so many scissors!";
            }
            if (Rocks == 0 && Scissors == 0 && Paper == 0)
            {
                return "I've discovered your stats.. or lack there of!";
            }
            return "I've discovered your stats!";
        }
    }
}
