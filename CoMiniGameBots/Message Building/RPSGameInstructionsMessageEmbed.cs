using CoMiniGameBots.MiniGames.RockPaperScissors;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class RPSGameInstructionsMessageEmbed
    {
        public static EmbedBuilder RPSChallengedPlayerInstructions(IUser Challenger)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Description = "Welcome to Rock Paper Scissors!";
            RPSBuilder.Title = $"You've been challenged by {Challenger.Username}!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            RPSBuilder.AddField("Instructions: ", "Reply directly to me what your submission is. You have five minutes to respond. Otherwise I'll time out!", false);
            RPSBuilder.AddField("Rock: ", "!shoot rock", false);
            RPSBuilder.AddField("Paper: ", "!shoot paper", false);
            RPSBuilder.AddField("Scissors: ", "!shoot scissors", false);

            return RPSBuilder;
        }
        public static EmbedBuilder RPSChallengingPlayerInstructions(IUser Challenged)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Description = "Welcome to Rock Paper Scissors!";
            RPSBuilder.Title = $"You've challenged {Challenged.Username}!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            RPSBuilder.AddField("Instructions: ", "Reply directly to me what your submission is. You have five minutes to respond. Otherwise I'll time out!", false);
            RPSBuilder.AddField("Rock: ", "!shoot rock", false);
            RPSBuilder.AddField("Paper: ", "!shoot paper", false);
            RPSBuilder.AddField("Scissors: ", "!shoot scissors", false);

            return RPSBuilder;
        }
    }
}
