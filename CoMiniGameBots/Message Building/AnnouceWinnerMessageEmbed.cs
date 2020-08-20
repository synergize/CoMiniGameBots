using CoMiniGameBots.Objects;
using Discord;

namespace CoMiniGameBots.Message_Building
{
    static class AnnounceWinnerMessageEmbed
    {
        public static EmbedBuilder RpsWinner(RpsGameObject game)
        {
            var winner = game.POne.IsWinner ? game.POne : game.PTwo;
            var loser = !game.POne.IsWinner ? game.POne : game.PTwo;
            var rpsBuilder = new EmbedBuilder();

            if (game.TotalWins < 3)
            {
                rpsBuilder.Title = "We've found a winner!";
            }
            else
            {
                rpsBuilder.Title = $"Best of Three, Game {game.TotalWins} found.";
                rpsBuilder.WithDescription($"This is best of three. Make sure to message me additional plays until the game has finished!");
            }

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
