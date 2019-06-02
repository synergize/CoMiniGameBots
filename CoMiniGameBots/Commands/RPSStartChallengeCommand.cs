using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
    public class RPSStartChallengeCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpschallenge")]
        public async Task RockPaperScissorsChallengeStart(IUser P2)
        {
            SocketUser P1 = Context.User;         
            if (CheckIfPlayerPlaying(P1, P2))
            {
                MessagePlayer(P1);
                MessagePlayer(P2);
                RPSGameRun Game = new RPSGameRun();
                Game.GameRun(P1, P2, Context.Channel);
            }
            else
            {
                await Context.Channel.SendMessageAsync("Player Already Playing");
            }
        }
        private async void MessagePlayer(IUser user)
        {
            await user.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSPlayerInstructions().Build());
        }
        private bool CheckIfPlayerPlaying(IUser P1, IUser P2)
        {
            foreach (var item in RPSGameDataClass.ActiveGames)
            {
                if (item.POne.User == P1 || item.PTwo.User == P1 || item.POne.User == P2 || item.PTwo.User == P2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}
