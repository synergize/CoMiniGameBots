using CoMiniGameBots.Commands;
using CoMiniGameBots.Message_Building;
using CoMiniGameBots.Objects;
using Discord;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.MiniGames.RockPaperScissors
{
    class RPSGameRun
    {
        public RPSGameObject GameRun(IUser POne, IUser PTwo)
        {
            RPSGameObject Test = new RPSGameObject(PopulatePlayerObject(POne), PopulatePlayerObject(PTwo));
            MessagePlayer(POne);
            MessagePlayer(PTwo);
            //TimedOutMessage(POne);
            return Test;
        }
        private async void MessagePlayer(IUser user)
        {
            await user.SendMessageAsync(null, false, RPSGameInstructionsMessageEmbed.RPSPlayerInstructions().Build());
        }
        private async void TimedOutMessage(IUser user)
        {
            await user.SendMessageAsync(null, false, GameTimedOutEmbed.RPSGameTimedOut().Build());
        }
        private RPSPlayerGameObject PopulatePlayerObject(IUser user)
        {
            RPSPlayerGameObject Player = new RPSPlayerGameObject(user);

            return Player;
        }

        
    }
}
