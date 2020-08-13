using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class PlayerAlreadyReadyMessageEmbed
    {
        public static EmbedBuilder RpsPlayerAlreadyReadyCheck(IUser user)
        {
            var rpsBuilder = new EmbedBuilder {Title = "You're already ready!"};
            rpsBuilder.WithColor(16580608);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            rpsBuilder.AddField(user.Username, "You can't play against yourself, that's cheating!", false);

            return rpsBuilder;
        }
    }
}
