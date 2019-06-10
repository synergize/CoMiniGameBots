using CoMiniGameBots.Commands;
using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors.Stats;
using CoMiniGameBots.Objects;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CoMiniGameBots.MiniGames.RockPaperScissors
{
    class RPSGameRun
    {
        public void GameRun(IUser POne, IUser PTwo, ISocketMessageChannel channel)
        {
            try
            {
                RPSGameObject ActiveGame = new RPSGameObject(PopulatePlayerObject(POne), PopulatePlayerObject(PTwo), channel);
                RPSGameDataClass.ActiveGames.Add(ActiveGame);
            }       
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public RPSGameObject GetPlayerEntry(IUser user, string play)
        {
            for (int i = 0; i < RPSGameDataClass.ActiveGames.Count; i++)
            {
                var item = RPSGameDataClass.ActiveGames[i];
                if (item.IsActive == true)
                {
                    if (item.POne.User.Id == user.Id)
                    {
                        item.POne.Choice = play;                        
                    }
                    else
                    {
                        item.PTwo.Choice = play;
                    }
                    if (item.PTwo.Choice != null && item.POne.Choice != null)
                    {
                        StatJsonController Save = new StatJsonController();
                        PopulateStatObject Populate = new PopulateStatObject();
                        var Winner = DetermineWinner(item);
                        RPSGameDataClass.PlayerStatsList.Add(Winner.POne);
                        RPSGameDataClass.PlayerStatsList.Add(Winner.PTwo);
                        item.IsActive = false;
                        Save.SaveStatsJson(Populate.SetPlayerStats(RPSGameDataClass.ActiveGames));
                        return Winner;
                    }
                    return item;
                }
            }
            return null;
        }
        private RPSGameObject DetermineWinner(RPSGameObject Game)
        {
            if (Game.POne.Choice == Game.PTwo.Choice)
            {
                Game.POne.IsWinner = false;
                Game.PTwo.IsWinner = false;
                return Game;
            }
            if ((Game.POne.Choice == "!scissors" && Game.PTwo.Choice == "!paper") ||
                (Game.POne.Choice == "!paper" && Game.PTwo.Choice == "!rock") ||
                (Game.POne.Choice == "!rock" && Game.PTwo.Choice == "!scissors"))
            {
                Game.POne.IsWinner = true;
                return Game;
            }
            else
            {
                Game.PTwo.IsWinner = true;
                return Game;
            }
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
