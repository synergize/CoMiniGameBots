using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;
using DiscordNetHelperLibrary;
using DiscordNetHelperLibrary.Constants;

namespace CoMiniGameBots
{
    internal class Program : DiscordBotBase
    {
        private static void Main() => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            await MainAsync(ApiAccessKeys.MiniGamesKey);
            await Commands.AddModulesAsync(typeof(Program).Assembly, null);
            Client.MessageReceived += Client_MessageRecieved;
            Client.Ready += Client_Ready;
            await Task.Delay(-1);
        }

        private async Task Client_MessageRecieved(SocketMessage messageParam)
        {
            if (!(messageParam is SocketUserMessage message)) return;
            var context = new SocketCommandContext(Client, message);
            
            if (context.Message == null || context.Message.Content == "") return;
            if (context.User.IsBot) return;

            if (context.Message.Content.Contains("!rps"))
            {
                await context.Channel.SendMessageAsync("Command structure has changed! Please make sure to do rps!<command>. Example: rps!challenge @user");
                return;
            }

            await FilterRpsReplies(message, context); // Checking Rock Paper Scissors replies.


            var argPos = 0;
            if (!(message.HasStringPrefix("rps!", ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))) return;

            var result = await Commands.ExecuteAsync(context, argPos, null);
            if (!result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing command. Text: {context.Message.Content} | Error: {result.ErrorReason}");
        }

        private async Task Client_Ready()
        {
            await Client.SetGameAsync("rps!help for details!", "https://discordapp.com/developers", ActivityType.Watching);
        }

        /// <summary>
        /// Checks passes in the user sending a message to see if they're in an active game.
        /// </summary>
        /// <param name="user"></param>
        /// <see cref="RpsGameManager.ActiveGames"/>
        /// <returns> 
        /// Returns trueif they're in an active game. 
        /// </returns>
        private static bool CheckGames(IUser user)
        {
            return RpsGameManager.ActiveGames.Any(activeGame => activeGame.Value.POne.User.Id == user.Id || activeGame.Value.PTwo.User.Id == user.Id);
        }

        /// <summary>
        /// Logic that checks a users message and we determine if the answer is for Rock Paper Scissors. If the message is acceptable, we head into the RPS game(s). 
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        private static async Task FilterRpsReplies(IMessage Message, SocketCommandContext Context)
        {
            var rpsCheck = Message.Content.ToLower().Trim();
            if (rpsCheck == "!rock" || rpsCheck == "!paper" || rpsCheck == "!scissors")
            {
                if (Context.Guild != null)
                {
                    await Message.DeleteAsync();
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} Please send your play directly to me in the future. I've deleted your message for safety, but your choice has been recorded!");
                }

                if (!CheckGames(Context.User))
                {
                    await Context.Channel.SendMessageAsync(null, false,
                        PlayerNoActiveGamesEmbed.RpsNoActiveGameEmbed(Context.User).Build());
                    return;
                }
                var entry = new RpsGameManager();
                var playerMessage = new DetermineMessageMain();
                var results = entry.GetPlayerEntry(Context.User, rpsCheck);
                if (results.IsRandom)
                {
                    await playerMessage.SendRandomMessageAsync(results, Context);
                }
                else
                {
                    await playerMessage.SendChallengedMessageAsync(results, Context);
                }

            }
        }
    }
}
