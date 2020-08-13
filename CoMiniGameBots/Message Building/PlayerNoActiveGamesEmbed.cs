using Discord;

namespace CoMiniGameBots.Message_Building
{
    public class PlayerNoActiveGamesEmbed
    {
        public static EmbedBuilder RpsNoActiveGameEmbed(IUser user)
        {
            var rpsBuilder = new EmbedBuilder
            {
                Title = "You're not in an active game!",
                Description =
                    $"{user.Username}, I was unable to locate an active game with you in it. Please challenge someone and try again."
            };
            rpsBuilder.WithColor(16580608);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
    }
}
