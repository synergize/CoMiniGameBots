using CoMiniGameBots.Objects;
using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class PlayerStatsMessageEmbed
    {
        public static EmbedBuilder RpsPlayerStats(RpsPlayerStatsDataModel stats, IUser user)
        {
            var rpsBuilder = new EmbedBuilder
            {
                Title = "Rock Paper Scissors Stats!", Description = $"{user.Username}, {BuildCustomMessage(stats)}"
            };
            rpsBuilder.AddField("Wins: ", $"{stats.Stats.NumberWins}", true);
            rpsBuilder.AddField("Losses: ", $"{stats.Stats.NumberLosses}", true);
            rpsBuilder.AddField("Draws: ", $"{stats.Stats.NumberDraws}", true);
            rpsBuilder.AddField("Rocks: ", $"{stats.Stats.NumberRocks}", true);
            rpsBuilder.AddField("Paper: ", $"{stats.Stats.NumberPaper}", true);
            rpsBuilder.AddField("Scissors: ", $"{stats.Stats.NumberScissors}", true);
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
        private static string BuildCustomMessage(RpsPlayerStatsDataModel stats)
        {
            var rocks = stats.Stats.NumberRocks;
            var paper = stats.Stats.NumberPaper;
            var scissors = stats.Stats.NumberScissors;
            if (rocks > paper && rocks > scissors)
            {
                return "stop throwing so many rocks! You'll hurt your wenis.";
            }
            if (paper > rocks && paper > scissors)
            {
                return "you can make a lot of airplanes with that paper usage!";
            }
            if (scissors > paper && scissors > rocks)
            {
                return "sever run with so many scissors!";
            }
            if (rocks == 0 && scissors == 0 && paper == 0)
            {
                return "I've discovered your stats.. or lack there of!";
            }
            return "I've discovered your stats!";
        }
    }
}
