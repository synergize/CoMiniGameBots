using CoMiniGameBots.Message_Building;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
   public class RPSHelpCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpshelp")]
        public async Task RPSHelp()
        {
            await Context.Channel.SendMessageAsync(null, false, RPSHelpEmbed.RPSHelp().Build());
        }
   }
}
