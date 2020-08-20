using Discord;

namespace CoMiniGameBots.Message_Building
{
    internal static class RpsGameInstructionsMessageEmbed
    {
        public static EmbedBuilder RpsChallengedPlayerInstructions(IUser Challenger)
        {
            var rpsBuilder = new EmbedBuilder
            {
                Description = "Welcome to Rock Paper Scissors!",
                Title = $"You've been challenged by {Challenger.Username}!"
            };
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            rpsBuilder.AddField("Instructions: ", "Reply directly to me what your submission is. You have five minutes to respond. Otherwise I'll time out!", false);
            rpsBuilder.AddField("Rock: ", "!rock", false);
            rpsBuilder.AddField("Paper: ", "!paper", false);
            rpsBuilder.AddField("Scissors: ", "!scissors", false);

            return rpsBuilder;
        }

        public static EmbedBuilder RpsChallengingPlayerInstructions(IUser Challenged)
        {
            var rpsBuilder = new EmbedBuilder
            {
                Description = "Welcome to Rock Paper Scissors!", Title = $"You've challenged {Challenged.Username}!"
            };
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            rpsBuilder.AddField("Instructions: ", "Reply directly to me what your submission is. You have five minutes to respond. Otherwise I'll time out!", false);
            rpsBuilder.AddField("Rock: ", "!rock", false);
            rpsBuilder.AddField("Paper: ", "!paper", false);
            rpsBuilder.AddField("Scissors: ", "!scissors", false);

            return rpsBuilder;
        }
    }
}
