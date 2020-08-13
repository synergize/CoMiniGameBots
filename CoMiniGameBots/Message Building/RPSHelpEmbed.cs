using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class RpsHelpEmbed
    {
        public static EmbedBuilder RpsHelp()
        {
            var rpsBuilder = new EmbedBuilder
            {
                Title = "Rock Paper Scissors Help!",
                Description = $"This bot allows for users to play the classic rock paper scissors!"
            };
            rpsBuilder.AddField("Challenge: ", "Challenge a friend by typing !rpschallenge @username", true);
            rpsBuilder.AddField("Stats: ", "Check out your stats by typing !rpsstats", true);
            rpsBuilder.AddField("Random Queue: ", "You can queue up for a random person. This can be someone from another discord server! !rpsrandom");
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
    }
}
