using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors.Stats;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
    public class RpsGetStatsCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpsstats")]
        public async Task GetPlayerStats()
        {
            IUser user = Context.User;
            var read = new StatJsonController();
            var playerStats = read.ReadStatsJson(user.Id);
            if (playerStats == null)
            {
                await Context.User.SendMessageAsync("You've not played a game yet. Challenge someone!");
            }
            else
            {
                await Context.User.SendMessageAsync(null, false, PlayerStatsMessageEmbed.RPSPlayerStats(playerStats, user).Build());
            }
        }
    }
}
