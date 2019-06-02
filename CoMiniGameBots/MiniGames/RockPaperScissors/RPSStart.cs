using CoMiniGameBots.Message_Building;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.MiniGames.RockPaperScissors
{
    static class RPSStart
    {
        private static bool PlayerWating = false;
        private static IUser UserCheck;
        //public static EmbedBuilder RPSStartGame(IUser user)
        //{   
            //if (RPSGameDataClass.POne != null && RPSGameDataClass.POne.Id == user.Id)
            //{
            //    return PlayerAlreadyReadyMessageEmbed.RPSPlayerAlreadyReadyCheck(user);
            //}
            //if (RPSGameDataClass.POne != null && RPSGameDataClass.PTwo != null)
            //{

            //}
            //if (RPSGameDataClass.IsPlayerWaiting == false)
            //{
            //    RPSGameDataClass.IsPlayerWaiting = true;
            //    RPSGameDataClass.POne = user;
            //    return PlayerWaitingMessageEmbed.RPSPlayerNeeded(user);
            //}
            //else
            //{
            //    RPSGameDataClass.IsPlayerWaiting = false;
            //    RPSGameDataClass.PTwo = user;
            //    RPSGameDataClass.ActiveGames.Add(RPSAddToGamesList.AddToGamesList());
            //    RPSGameDataClass.IsGameBegin = true;
            //    return GameStartedMessageEmbed.RPSGameStartedMessage(user);                
            //}
        //}
    }
}
