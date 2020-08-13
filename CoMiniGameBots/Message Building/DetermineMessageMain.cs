using CoMiniGameBots.Objects;
using Discord;
using Discord.Commands;
using Discord.Rest;
using System.Threading.Tasks;

namespace CoMiniGameBots.Message_Building
{
    public class DetermineMessageMain
    {
        public async Task<RestUserMessage> SendChallengedMessageAsync(RpsGameObject Results, SocketCommandContext Context)
        {
                if (Results == null)
                {
                    return await Context.Channel.SendMessageAsync("Waiting on your opponent!");
                }

                if (Results.POne.IsWinner)
                {
                    return await Results.GameChannel.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.POne, Results.PTwo).Build());
                }

                if (Results.PTwo.IsWinner)
                {
                    return await Results.GameChannel.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.PTwo, Results.POne).Build());
                    
                }

                if (Results.POne.IsWinner == false && Results.PTwo.IsWinner == false && Results.POne.Choice != null && Results.PTwo.Choice != null)
                {
                    return await Results.GameChannel.SendMessageAsync($"{Results.POne.User.Mention} and {Results.PTwo.User.Mention}, I'm lazy.. you've both picked the same thing. Draw!");                    
                }
                return await Context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());
        }

        public async Task SendRandomMessageAsync(RpsGameObject Results, SocketCommandContext Context)
        {
            if (Results == null)
            {
                await Context.Channel.SendMessageAsync("Waiting on your opponent!");
                return;

            }
            if (Results.POne.IsWinner)
            {
                await Results.POne.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.POne, Results.PTwo).Build());
                await Results.PTwo.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.POne, Results.PTwo).Build());
                return;

            }

            if (Results.PTwo.IsWinner)
            {
                await Results.POne.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.PTwo, Results.POne).Build());
                await Results.PTwo.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.PTwo, Results.POne).Build());
                return;

            }

            if (Results.POne.IsWinner == false && Results.PTwo.IsWinner == false && Results.POne.Choice != null && Results.PTwo.Choice != null)
            {
                await Results.POne.User.SendMessageAsync($"I'm lazy.. you've both picked the same thing. Draw!");
                await Results.PTwo.User.SendMessageAsync($"I'm lazy.. you've both picked the same thing. Draw!");
                return;
            }
            await Context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());
        }
    }
}
