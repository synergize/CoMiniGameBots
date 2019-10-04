using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
    public class RPSStartChallengeCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// !rpschallenge command. This allows a discord user to pass in a <see cref="IUser"/> of another user/player and begins the process of starting a Rock Paper Scissors game. 
        /// </summary>
        /// <param name="P2"></param>
        /// <returns></returns>
        [Command("rpschallenge")]
        public async Task RockPaperScissorsChallengeStart(IUser P2)
        {
            SocketUser P1 = Context.User;  
            if (P1.Id == P2.Id)
            {
                return;
            }
            if (!CheckIfPlayerPlaying(P1) && !CheckIfPlayerPlaying(P2))
            {
                MessagePlayers(P1, P2);
                RPSGameRun Game = new RPSGameRun();
                Game.GameRunChallenge(P1, P2, Context.Channel);                
            }
            else
            {
                var ActiveGames = RPSStaticGameLists.GetAllActiveGame();
                var checkP1 = ActiveGames.Find(x => x.POne.User == P1 || x.POne.User == P2);
                var checkP2 = ActiveGames.Find(x => x.PTwo.User == P1 || x.PTwo.User == P2);

                if (checkP1 == null && checkP2 == null)
                {
                    await Context.Channel.SendMessageAsync($"No Users Found");
                }
                else if (checkP1 == null)
                {
                    await Context.Channel.SendMessageAsync($"{P2.Mention} Already Playing");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{P1.Mention} Already Playing");
                }
                
                
            }
        }
        /// <summary>
        /// Method used to send a message to both players. This was done to tailor the messages to let the users know who challenged them. 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        private async void MessagePlayers(IUser P1, IUser P2)
        {
            await P1.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSChallengingPlayerInstructions(P2).Build());
            await P2.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSChallengedPlayerInstructions(P1).Build());
        }
        /// <summary>
        /// Boolean function that returns if the player is already in an active game. Currently only allowing a player to queue up for one game at a time.
        /// There is logic in here to remove the instance of a game if a game went "stale" after 5 minutes. 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns></returns>
        private bool CheckIfPlayerPlaying(IUser player)
        {
            var ActiveGames = RPSStaticGameLists.GetAllActiveGame();
            if (ActiveGames.Exists(x => x.PTwo.User == player || x.POne.User == player))
            {
                var currentEntry = ActiveGames.Find(x => x.POne.User == player || x.PTwo.User == player);
                if (currentEntry.StartTime.AddMinutes(5) < DateTime.UtcNow)
                {
                    RPSStaticGameLists.ActiveGames.Remove(currentEntry);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
