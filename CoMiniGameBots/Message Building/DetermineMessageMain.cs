using CoMiniGameBots.Objects;
using Discord;
using Discord.Commands;
using Discord.Rest;
using System.Threading.Tasks;

namespace CoMiniGameBots.Message_Building
{
    public class DetermineMessageMain
    {
        public async Task<RestUserMessage> SendChallengedMessageAsync(RpsGameObject results, SocketCommandContext context)
        {
                if (results == null)
                {
                    return await context.Channel.SendMessageAsync("Waiting on your opponent!");
                }

                if (results.POne.IsWinner == false && results.PTwo.IsWinner == false && results.POne.Choice != null && results.PTwo.Choice != null)
                {
                    return await results.GameChannel.SendMessageAsync($"{results.POne.User.Mention} and {results.PTwo.User.Mention}, I'm lazy.. you've both picked the same thing. Draw! Make sure to go again. ");                    
                }

                if (results.POne.IsWinner || results.PTwo.IsWinner)
                {
                    return await results.GameChannel.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(results).Build());
                }
                return await context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());
        }

        //public async Task SendRandomMessageAsync(RpsGameObject Results, SocketCommandContext Context)
        //{
        //    if (Results == null)
        //    {
        //        await Context.Channel.SendMessageAsync("Waiting on your opponent!");
        //        return;

        //    }
        //    if (Results.POne.IsWinner)
        //    {
        //        await Results.POne.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.POne, Results.PTwo).Build());
        //        await Results.PTwo.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.POne, Results.PTwo).Build());
        //        return;

        //    }

        //    if (Results.PTwo.IsWinner)
        //    {
        //        await Results.POne.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.PTwo, Results.POne).Build());
        //        await Results.PTwo.User.SendMessageAsync(null, false, AnnounceWinnerMessageEmbed.RpsWinner(Results.PTwo, Results.POne).Build());
        //        return;

        //    }

        //    if (Results.POne.IsWinner == false && Results.PTwo.IsWinner == false && Results.POne.Choice != null && Results.PTwo.Choice != null)
        //    {
        //        await Results.POne.User.SendMessageAsync($"I'm lazy.. you've both picked the same thing. Draw!");
        //        await Results.PTwo.User.SendMessageAsync($"I'm lazy.. you've both picked the same thing. Draw!");
        //        return;
        //    }
        //    await Context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());
        //}
    }
}
