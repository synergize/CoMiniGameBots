using CoMiniGameBots.Objects;
using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class AnnounceWinnerMessageEmbed
    {
        public static EmbedBuilder RpsWinner(RpsPlayerGameObject winner, RpsPlayerGameObject loser)
        {
            var rpsBuilder = new EmbedBuilder {Title = "We've found a winner!"};
            rpsBuilder.AddField("Winner: ", $"{winner.User.Mention}", true);
            rpsBuilder.AddField("Loser: ", $"{loser.User.Mention}", true);
            rpsBuilder.AddField("Winner Choice: ", $"{winner.Choice.Remove(0, 1)}!", true);
            rpsBuilder.AddField("Loser Choice: ", $"{loser.Choice.Remove(0, 1)}!", true);
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
    }
}
