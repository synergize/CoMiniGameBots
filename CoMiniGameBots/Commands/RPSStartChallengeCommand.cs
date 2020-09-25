using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using CoMiniGameBots.Exceptions;

namespace CoMiniGameBots.Commands
{
    public class RpsStartChallengeCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// !rpschallenge command. This allows a discord user to pass in a <see cref="IUser"/> of another user/player and begins the process of starting a Rock Paper Scissors game. 
        /// </summary>
        /// <param name="p2"></param>
        /// <returns></returns>
        [Command("challenge")]
        public async Task RockPaperScissorsChallengeStart(IUser p2)
        {
            var p1 = Context.User;  
            if (p1.Id == p2.Id)
            {
                await Context.Channel.SendMessageAsync($"{p1.Mention} you can't challenge yourself. That's cheating. I'm telling mom!");
                return;
            }

            if (!RpsGameManager.CheckIfPlayerPlaying(p2) && !RpsGameManager.CheckIfPlayerPlaying(p1))
            {
                MessagePlayers(p1, p2);
                var game = new RpsGameManager();
                game.GameRunChallenge(p1, p2, Context.Channel);                
            }
            else
            {

                try
                {
                    RpsGameManager.DetermineAndRemoveInactiveGames(p1, p1);
                    RpsGameManager.DetermineAndRemoveInactiveGames(p2, p1);
                }
                catch (GameNotExpiredException e)
                {
                    await Context.Channel.SendMessageAsync(e.Message);
                }
                catch (GameExpiredException e)
                {
                    await Context.Channel.SendMessageAsync(e.Message);
                }
            }
        }

        /// <summary>
        /// Method used to send a message to both players. This was done to tailor the messages to let the users know who challenged them. 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        private static async void MessagePlayers(IUser P1, IUser P2)
        {
            await P1.SendMessageAsync(null, false, RpsGameInstructionsMessageEmbed.RpsChallengingPlayerInstructions(P2).Build());
            await P2.SendMessageAsync(null, false, RpsGameInstructionsMessageEmbed.RpsChallengedPlayerInstructions(P1).Build());
        }
    }
}
