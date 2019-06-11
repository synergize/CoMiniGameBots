using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class RPSHelpEmbed
    {
        public static EmbedBuilder RPSHelp()
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Rock Paper Scissors Help!";
            RPSBuilder.Description = $"This bot allows for users to play the classic rock paper scissors!";
            RPSBuilder.AddField("Challenge: ", "Challenge a friend by typing !rpschallenge @username", true);
            RPSBuilder.AddField("Stats: ", "Check out your stats by typing !rpsstats", true);
            RPSBuilder.AddField("Random Queue: ", "You can queue up for a random person. This can be someone from another discord server! !rpsrandom");
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}
