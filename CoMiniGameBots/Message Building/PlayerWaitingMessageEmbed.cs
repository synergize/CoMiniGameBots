using Discord.Commands;
using System;
using Discord;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CoMiniGameBots.Message_Building
{
    static class PlayerWaitingMessageEmbed
    {
        public static EmbedBuilder RPSPlayerNeeded(IUser user)
        {
                EmbedBuilder RPSBuilder = new EmbedBuilder();
                RPSBuilder.Title = "Additional player needed!";
                RPSBuilder.WithColor(16580608);
                RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
                RPSBuilder.AddField(user.Username, "You've been added to the queue. Have another friend join by them typing !rps.", false);

                return RPSBuilder;           
        }
    }

}
