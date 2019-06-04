using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors;
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
            if (RPSCheck == "!rock" || RPSCheck == "!paper" || RPSCheck == "!scissors")
            {
                if (!CheckGames(Context.User))
                {
                    await Context.Channel.SendMessageAsync(null, false,
                        PlayerNoActiveGamesEmbed.RPSPlayerNeeded(Context.User).Build());
                    return;
                }
                RPSGameRun Entry = new RPSGameRun();

                var Results = Entry.GetPlayerEntry(Context.User, RPSCheck);
                if (Results == null)
                {
                    await Context.Channel.SendMessageAsync("Waiting on your opponent!");
                    return;
                }
                if (Results.POne.IsWinner == true)
                {
                    await Results.GameChannel.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.POne).Build());
                    return;
                }
                else if (Results.PTwo.IsWinner == true)
                {
                    await Results.GameChannel.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.PTwo).Build());
                    return;
                }
                else if (Results.POne.IsWinner == false && Results.PTwo.IsWinner == false && Results.POne.Choice != null && Results.PTwo.Choice != null)
                {
                    await Results.GameChannel.SendMessageAsync("Draw!");
                    return;
                }
                else
                {
                    await Context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());
                    return;
                }
                
            }

            int ArgPos = 0;
            if (!(Message.HasCharPrefix('!', ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;

            var Result = await Commands.ExecuteAsync(Context, ArgPos, null);
            if (!Result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing command. Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
        }
        private async Task Client_Ready()
        {
            await Client.SetGameAsync("!rpshelp for details!", "https://discordapp.com/developers", ActivityType.Playing);
        }

        //If someone adds a reaction, run x code. 
        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel Channel, SocketReaction Reaction)
        {
            //If a bot sends the reaction, disregard. 
            if (((SocketUser)Reaction.User).IsBot) return;
        }

        private bool CheckGames(IUser user)
        {
            foreach (var ActiveGame in RPSGameDataClass.ActiveGames)
            {
                if (ActiveGame.POne.User.Id == user.Id || ActiveGame.PTwo.User.Id == user.Id)
                {
                    if (ActiveGame.IsActive)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
