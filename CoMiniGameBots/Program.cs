using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoMiniGameBots
{
    internal class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;
        private static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {

            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug

            });

            Client.MessageReceived += Client_MessageRecieved;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            Client.Ready += Client_Ready;
            Client.Log += Log;

            var token = BotToken.Token;
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();
            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            return Task.CompletedTask;
        }

        private async Task Client_MessageRecieved(SocketMessage MessageParam)
        {
            var message = MessageParam as SocketUserMessage;
            var context = new SocketCommandContext(Client, message);
            
            if (context.Message == null || context.Message.Content == "") return;
            if (context.User.IsBot) return;

            
            await FilterRpsReplies(message, context); // Checking Rock Paper Scissors replies.


            var argPos = 0;
            if (!(message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))) return;

            var result = await Commands.ExecuteAsync(context, argPos, null);
            if (!result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing command. Text: {context.Message.Content} | Error: {result.ErrorReason}");
        }
        private async Task Client_Ready()
        {
            await Client.SetGameAsync("!rpshelp for details!", "https://discordapp.com/developers", ActivityType.Playing);
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
            return RpsGameManager.ActiveGames.Any(activeGame => activeGame.POne.User.Id == user.Id || activeGame.PTwo.User.Id == user.Id);
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
