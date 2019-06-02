﻿using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class RPSHelpEmbed
    {
        public static EmbedBuilder RPSWinner()
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Rock Paper Scissors Help!";
            RPSBuilder.Description = $"This bot allows for users to play the classic rock paper scissors!";
            RPSBuilder.AddField("Challenge: ", "Challenge a friend by typing !rpschallenege @username", true);
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return RPSBuilder;
        }
    }
}