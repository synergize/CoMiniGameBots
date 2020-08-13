using Discord;

namespace CoMiniGameBots.Message_Building
{
    public static class GameTimedOutEmbed
    {
        public static EmbedBuilder RpsGameTimedOut()
        {
            var rpsBuilder = new EmbedBuilder
            {
                Title = "Game Timed Out", Description = "Game timed out. Response wasn't given in time."
            };
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
    }
}
