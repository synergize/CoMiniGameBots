using CoMiniGameBots.Message_Building;
using Discord.Commands;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
   public class RpsHelpCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpshelp")]
        public async Task RpsHelp()
        {
            await Context.Channel.SendMessageAsync(null, false, RpsHelpEmbed.RpsHelp().Build());
        }
   }
}
