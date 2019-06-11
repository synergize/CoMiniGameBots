using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Static_Data;
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
            if (P1.Id == P2.Id)
            {
                return;
            }
            if (CheckIfPlayerPlaying(P1, P2))
            {
                MessagePlayers(P1, P2);
                RPSGameRun Game = new RPSGameRun();
                Game.GameRunChallenge(P1, P2, Context.Channel);
                
            }
            else
            {
                await Context.Channel.SendMessageAsync("Player Already Playing");
                
            }
        }
        private async void MessagePlayers(IUser P1, IUser P2)
        {
            await P1.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSChallengingPlayerInstructions(P2).Build());
            await P2.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSChallengedPlayerInstructions(P1).Build());
        }
        private bool CheckIfPlayerPlaying(IUser P1, IUser P2)
        {
            foreach (var item in RPSStaticGameLists.ActiveGames)
            {
                if (item.POne.User == P1 || item.PTwo.User == P1 || item.POne.User == P2 || item.PTwo.User == P2)
                {        
                    if (item.StartTime.AddMinutes(5) < DateTime.UtcNow)
                    {
                        RPSStaticGameLists.ActiveGames.Remove(item);
                        return true;
                    }
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
