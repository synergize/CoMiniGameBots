using Discord;

namespace CoMiniGameBots.Message_Building
{
    class GameInprogressMessageEmbed
    {
        public static EmbedBuilder RpsGameStartedMessage(IUser user)
        {
            var rpsBuilder = new EmbedBuilder {Title = "Game Already in progress!"};
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            rpsBuilder.AddField(user.Username, "There's already a game in progress. Please wait for it to complete before trying again.", false);

            return rpsBuilder;
        }
    }
}
