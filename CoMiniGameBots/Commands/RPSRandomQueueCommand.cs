using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;
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
    public class RPSRandomQueueCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rpsrandom")]
        public async Task RandomPlayerQueue()
        {
            IUser user = Context.User;
            ISocketMessageChannel channel = Context.Message.Channel;
            try
            {
                if (!CheckIfInQueue(user))
                {
                    RPSGameRun Game = new RPSGameRun();
                    if (RPSStaticGameLists.ActiveQueue.Count >= 1)
                    {
                        var P1 = RPSStaticGameLists.ActiveQueue.Dequeue();
                        var P2 = user;
                        RPSGameObject ActiveGame = new RPSGameObject(P1, Game.PopulatePlayerObject(P2));
                        RPSStaticGameLists.ActiveGames.Add(ActiveGame);
                        MessagePlayers(P1.User, P2);
                    }
                    else
                    {
                        Game.GameRunRandom(user, channel);
                        await Context.Channel.SendMessageAsync("You've been added to the queue. Please wait for someone to join! I'll message you when the game is ready.");
                    }
                }
                else
                {
                    await Context.Channel.SendMessageAsync("You're already queued!");
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private bool CheckIfInQueue(IUser player)
        {
            var queue = RPSStaticGameLists.ActiveQueue;

            foreach (var item in queue)
            {
                if (item.User.Id == player.Id)
                {
                    return true;
                }
            }
            return false;
        }
        private async void MessagePlayers(IUser P1, IUser P2)
        {
            await P1.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSChallengingPlayerInstructions(P2).Build());
            await P2.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSChallengedPlayerInstructions(P1).Build());
        }
    }
}
