using CoMiniGameBots.Commands;
using CoMiniGameBots.Message_Building;
using CoMiniGameBots.MiniGames.RockPaperScissors.Stats;
using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
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
        public void GameRunChallenge(IUser POne, IUser PTwo, ISocketMessageChannel channel)
        {
            try
            {
                RPSGameObject ActiveGame = new RPSGameObject(PopulatePlayerObject(POne), PopulatePlayerObject(PTwo), channel);
                RPSStaticGameLists.ActiveGames.Add(ActiveGame);
            }       
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
       public void GameRunRandom(IUser player, ISocketMessageChannel channel)
        {
            RPSStaticGameLists.ActiveQueue.Enqueue(PopulatePlayerObject(player));
        }
        public RPSGameObject GetPlayerEntry(IUser user, string play)
        {
            for (int i = 0; i < RPSStaticGameLists.ActiveGames.Count; i++)
            {
                 var CurrentGame = RPSStaticGameLists.ActiveGames[i];
                if (CurrentGame.IsActive == true)
                {
                    if (CurrentGame.POne.User.Id == user.Id && CurrentGame.POne.Choice == null)
                    {
                        CurrentGame.POne.Choice = play;
                        return IsWinner(CurrentGame);
                    }
                    else if (CurrentGame.PTwo.User.Id == user.Id && CurrentGame.PTwo.Choice == null)
                    {
                        CurrentGame.PTwo.Choice = play;
                        return IsWinner(CurrentGame);
                    }                 
                }
            }
            return null;
        }
        private RPSGameObject IsWinner(RPSGameObject game)
        {
            if (game.PTwo.Choice != null && game.POne.Choice != null)
            {
                StatJsonController Save = new StatJsonController();
                PopulateStatObject Populate = new PopulateStatObject();
                var Winner = DetermineWinner(game);
                RPSStaticGameLists.PlayerStatsList.Add(Winner.POne);
                RPSStaticGameLists.PlayerStatsList.Add(Winner.PTwo);
                game.IsActive = false;
                Save.SaveStatsJson(Populate.SetPlayerStats(RPSStaticGameLists.ActiveGames));
                return Winner;
            }
            return game;
            
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
        public RPSPlayerGameObject PopulatePlayerObject(IUser user)
        {
            RPSPlayerGameObject Player = new RPSPlayerGameObject(user);

            return Player;
        }        
    }
}
