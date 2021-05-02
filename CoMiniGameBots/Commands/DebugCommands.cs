using System.Collections.Concurrent;
using System.ComponentModel;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;

namespace CoMiniGameBots.Commands
{
    public class DebugCommands : ModuleBase<SocketCommandContext>
    {

        [Command("dump")]
        public async Task GetGames()
        {
            if (IsDeveloper().Result)
            {
                var count = 0;
                if (RpsGameManager.ActiveGames.Count > 0)
                {
                    foreach (var item in RpsGameManager.ActiveGames)
                    {
                        count++;
                        var debug = new EmbedBuilder {Title = $"{count}) Game"};
                        debug.AddField("Player 1 Username: ", $"{item.Value.POne.User.Username}");
                        debug.AddField("Player 1 Choice: ", item.Value.POne.Choice ?? "null");
                        debug.AddField("Player 2 Username: ", $"{item.Value.PTwo.User.Username}");
                        debug.AddField("Player 2 Choice: ", item.Value.PTwo.Choice ?? "null");
                        await Context.Channel.SendMessageAsync(null, false, debug.Build());
                    }
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"No active games.");
                }
            }

        }

        [Command("clearGames")]
        public async Task ClearGames()
        {
            if (IsDeveloper().Result)
            {
                RpsGameManager.ActiveGames = new ConcurrentDictionary<ulong, RpsGameObject>();
            }
        }

        private async Task<bool> IsDeveloper()
        {
            const ulong ownerId = 129804455964049408;

            if (Context.User.Id == ownerId)
            {
                return true;
            }

            await Context.Channel.SendMessageAsync("You're not my owner. You can't do this.");
            return false;
        }
    }
}
