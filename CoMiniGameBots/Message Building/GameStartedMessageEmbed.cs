using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class GameStartedMessageEmbed
    {
        public static EmbedBuilder RpsGameStartedMessage(IUser user)
        {
            var rpsBuilder = new EmbedBuilder {Title = "Game Started!"};
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            rpsBuilder.AddField(user.Username, "The Game has begun! I've messaged you both with details, please make sure to reply to me via Direct Message for your input!", false);

            return rpsBuilder;
        }
    }
}
