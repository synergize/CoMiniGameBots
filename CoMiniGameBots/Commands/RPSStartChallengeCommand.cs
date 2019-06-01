using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
    public class RPSStartChallengeCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpschallenge")]
        public async Task RockPaperScissorsChallengeStart(IUser Challenged)
        {
            //await Context.Channel.SendMessageAsync("", false, RPSStart.RPSStartGame(Context.User).Build());
            //if (RPSGameDataClass.IsGameBegin == true)
            //{
            //   await RPSGameDataClass.POne.SendMessageAsync("Nerd!");
            //}
            RPSGameRun Game = new RPSGameRun();
            Game.GameRun(Context.User, Challenged);
        }
    }
}
