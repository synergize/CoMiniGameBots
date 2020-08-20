using System;
using System.Collections.Generic;
using System.Text;
using CoMiniGameBots.Objects;
using Discord;

namespace CoMiniGameBots.Message_Building
{
    public static class BestOfThreeContinuationMessageEmbed
    {
        public static EmbedBuilder ContinuePlayingMessageEmbed(RpsGameObject game, IUser user)
        {
            var opponent = game.POne.User == user ? game.PTwo.User : game.POne.User;

            var rpsBuilder = new EmbedBuilder { Title = "Continue Playing!" };
            rpsBuilder.WithDescription($"No winner has been determined between you or {opponent.Username}. It's best of three. Provide me with another submission. (!rock, !paper or !scissors)");
            rpsBuilder.WithColor(4124426);
            rpsBuilder.WithFooter("Contact Coaction#5994 for any issues. This is a work in progress.");

            return rpsBuilder;
        }
    }
}
