using Discord;

namespace CoMiniGameBots.Message_Building
{
    public static class WaitingPlayerMessageEmbed
    {
        public static EmbedBuilder WaitingForOpponent()
        {
            var rpsBuilder = new EmbedBuilder
            {
                Title = "Waiting for your opponent!",
                Description =
                    "You've entered your entry before your opponent. When they send theirs I'll post the results in the discord where we started!"
            };
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
    }
}
