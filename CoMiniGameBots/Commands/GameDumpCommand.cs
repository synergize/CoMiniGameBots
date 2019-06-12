using CoMiniGameBots.Static_Data;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Commands
{
    public class GameDumpCommand : ModuleBase<SocketCommandContext>
    {
        private readonly ulong OwnerID = 129804455964049408;
        [Command("rpsdump")]
        public async Task GetGames()
        {
            IUser User = Context.User;
            if (User.Id == OwnerID)
            {
                int count = 0;
                foreach (var item in RPSStaticGameLists.ActiveGames)
                {
                    count++;
                    EmbedBuilder Debug = new EmbedBuilder();
                    Debug.Title = $"{count}) Game";
                    Debug.AddField("Player 1 Username: ", $"{item.POne.User.Username}");
                    if (item.POne.Choice != null)
                    {
                        Debug.AddField("Player 1 Choice: ", item.POne.Choice);
                    }
                    else
                    {
                        Debug.AddField("Player 1 Choice: ", "null");
                    }
                    Debug.AddField("Player 2 Username: ", $"{item.PTwo.User.Username}");
                    if (item.PTwo.Choice != null)
                    {
                        Debug.AddField("Player 2 Choice: ", item.PTwo.Choice);
                    }
                    else
                    {
                        Debug.AddField("Player 2 Choice: ", "null");
                    }
                    await Context.Channel.SendMessageAsync(null, false, Debug.Build());
                }

                count = 0;
                foreach (var item in RPSStaticGameLists.ActiveQueue)
                {
                    count++;
                    EmbedBuilder Debug = new EmbedBuilder();
                    Debug.Title = $"{count}) Queued Player";
                    Debug.AddField("Player Username: ", $"{item.User.Username}");
                    if (item.Choice != null)
                    {
                        Debug.AddField("Player Choice: ", item.Choice);
                    }
                    else
                    {
                        Debug.AddField("Player Choice: ", "null");
                    }
                    await Context.Channel.SendMessageAsync(null, false, Debug.Build());
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("You're not my owner. You can't do this.");
            }

        }
    }
}
