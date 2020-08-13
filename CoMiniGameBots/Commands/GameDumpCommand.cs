using CoMiniGameBots.Static_Data;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using CoMiniGameBots.MiniGames.RockPaperScissors;

namespace CoMiniGameBots.Commands
{
    public class GameDumpCommand : ModuleBase<SocketCommandContext>
    {
        private const ulong OwnerId = 129804455964049408;

        [Command("rpsdump")]
        public async Task GetGames()
        {
            IUser user = Context.User;
            if (user.Id == OwnerId)
            {
                var count = 0;
                if (RpsGameManager.ActiveGames.Count > 0)
                {
                    foreach (var item in RpsGameManager.ActiveGames)
                    {
                        count++;
                        var debug = new EmbedBuilder {Title = $"{count}) Game"};
                        debug.AddField("Player 1 Username: ", $"{item.POne.User.Username}");
                        debug.AddField("Player 1 Choice: ", item.POne.Choice ?? "null");
                        debug.AddField("Player 2 Username: ", $"{item.PTwo.User.Username}");
                        debug.AddField("Player 2 Choice: ", item.PTwo.Choice ?? "null");
                        await Context.Channel.SendMessageAsync(null, false, debug.Build());
                    }
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"No active games.");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("You're not my owner. You can't do this.");
            }

        }
    }
}
