using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CoMiniGameBots
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

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

            string Token = BotToken.Token;
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            return Task.CompletedTask;
        }

        private async Task Client_MessageRecieved(SocketMessage MessageParam)
        {
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);
            string RPSCheck = Message.Content.ToLower();

            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            if (RPSCheck == "!shoot rock" || RPSCheck == "!shoot paper" || RPSCheck == "!shoot scissor")
            {
                Console.WriteLine("RPS Message Recieved");
                return;
            }

            int ArgPos = 0;
            if (!(Message.HasCharPrefix('!', ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;

            var Result = await Commands.ExecuteAsync(Context, ArgPos, null);
            if (!Result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing command. Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
        }
        private async Task Client_Ready()
        {
            await Client.SetGameAsync("!coHelp for details!", "https://discordapp.com/developers", ActivityType.Playing);
        }

        //If someone adds a reaction, run x code. 
        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel Channel, SocketReaction Reaction)
        {
            //If a bot sends the reaction, disregard. 
            if (((SocketUser)Reaction.User).IsBot) return;
        }

        private string DetermineWinner(RPSGameObject Game)
        {
            if (Game.POne.Choice == Game.PTwo.Choice) return "Draw!";
            if ((Game.POne.Choice == "scissor" && Game.PTwo.Choice == "paper") ||
                (Game.POne.Choice == "paper" && Game.PTwo.Choice == "rock") ||
                (Game.POne.Choice == "rock" && Game.PTwo.Choice == "scissor"))
                return $"{Game.POne.User.Mention} Won!";
            else
            {
                return $"{Game.PTwo.User.Mention} Won!";
            }
        }
    }
}
