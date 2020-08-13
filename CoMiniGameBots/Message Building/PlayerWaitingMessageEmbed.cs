using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class PlayerWaitingMessageEmbed
    {
        public static EmbedBuilder RpsPlayerNeeded(IUser user)
        {
            var rpsBuilder = new EmbedBuilder {Title = "Additional player needed!"};
            rpsBuilder.WithColor(16580608);
                rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
                rpsBuilder.AddField(user.Username, "You've been added to the queue. Have another friend join by them typing !rps.", false);

                return rpsBuilder;           
        }
    }

}
