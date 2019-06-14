using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.Message_Building
{
    public class DetermineMessageMain
    {
        public async Task<RestUserMessage> SendChallengedMessageAsync(RPSGameObject Results, SocketCommandContext Context)
        {
                if (Results == null)
                {
                    return await Context.Channel.SendMessageAsync("Waiting on your opponent!");
                    
                }
                if (Results.POne.IsWinner == true)
                {
                    return await Results.GameChannel.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.POne, Results.PTwo).Build());

                }
                else if (Results.PTwo.IsWinner == true)
                {
                    return await Results.GameChannel.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.PTwo, Results.POne).Build());
                    
                }
                else if (Results.POne.IsWinner == false && Results.PTwo.IsWinner == false && Results.POne.Choice != null && Results.PTwo.Choice != null)
                {
                   return await Results.GameChannel.SendMessageAsync($"{Results.POne.User.Mention} and {Results.PTwo.User.Mention}, I'm lazy.. you've both picked the same thing. Draw!");                    
                }
                else
                {
                    return await Context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());                   
                }
        }
        public async Task SendRandomMessageAsync(RPSGameObject Results, SocketCommandContext Context)
        {
            if (Results == null)
            {
                await Context.Channel.SendMessageAsync("Waiting on your opponent!");
                return;

            }
            if (Results.POne.IsWinner == true)
            {
                await Results.POne.User.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.POne, Results.PTwo).Build());
                await Results.PTwo.User.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.POne, Results.PTwo).Build());
                return;

            }
            else if (Results.PTwo.IsWinner == true)
            {
                await Results.POne.User.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.PTwo, Results.POne).Build());
                await Results.PTwo.User.SendMessageAsync(null, false, AnnouceWinnerMessageEmbed.RPSWinner(Results.PTwo, Results.POne).Build());
                return;

            }
            else if (Results.POne.IsWinner == false && Results.PTwo.IsWinner == false && Results.POne.Choice != null && Results.PTwo.Choice != null)
            {
                await Results.POne.User.SendMessageAsync($"I'm lazy.. you've both picked the same thing. Draw!");
                await Results.PTwo.User.SendMessageAsync($"I'm lazy.. you've both picked the same thing. Draw!");
                return;
            }
            else
            {
                 await Context.Channel.SendMessageAsync(null, false, WaitingPlayerMessageEmbed.WaitingForOpponent().Build());
                return;
            }
        }
    }
}
