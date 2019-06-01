using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class RPSGameInstructionsMessageEmbed
    {
        public static EmbedBuilder RPSPlayerInstructions()
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Welcome to Rock Paper Scissors!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            //RPSBuilder.AddField(user.Username, $"Your game has begun against {DeterminePlayer(user)}", false);
            RPSBuilder.AddField("Instructions: ", "Reply directly to me what your submission is I'll list the possible submissions below!", false);
            RPSBuilder.AddField("Rock: ", "!shoot rock", false);
            RPSBuilder.AddField("Paper: ", "!shoot paper", false);
            RPSBuilder.AddField("Scissors: ", "!shoot scissor", false);

            return RPSBuilder;
        }
        private static IUser DeterminePlayer(IUser user)
        {
            if (user.Id == RPSGameDataClass.POne.Id)
            {
                return RPSGameDataClass.PTwo;
            }
            else
            {
                return RPSGameDataClass.POne;
            }
        }
    }
}
