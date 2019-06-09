using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors.Stats;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
    public class RPSGetStatsCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpsstats")]
        public async Task GetPlayerStats()
        {
            IUser user = Context.User;
            StatJsonController Read = new StatJsonController();
            var PlayerStats = Read.ReadStatsJson(user.Id);
            if (PlayerStats == null)
            {
                await Context.User.SendMessageAsync("You've not played a game yet. Challenge someone!", false, null);
                return;
            }
            else
            {
                await Context.User.SendMessageAsync(null, false, PlayerStatsMessageEmbed.RPSPlayerStats(PlayerStats, user).Build());
            }
        }
    }
}
