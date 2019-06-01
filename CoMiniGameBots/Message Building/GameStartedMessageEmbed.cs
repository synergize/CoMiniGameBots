using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.Message_Building
{
    static class GameStartedMessageEmbed
    {
        public static EmbedBuilder RPSGameStartedMessage(IUser user)
        {
            EmbedBuilder RPSBuilder = new EmbedBuilder();
            RPSBuilder.Title = "Game Started!";
            RPSBuilder.WithColor(4124426);
            RPSBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");
            RPSBuilder.AddField(user.Username, "The Game has begun! I've messaged you both with details, please make sure to reply to me via Direct Message for your input!", false);

            return RPSBuilder;
        }
    }
}
