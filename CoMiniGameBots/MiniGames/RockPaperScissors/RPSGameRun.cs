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
        /// <summary>
        /// Kicks off an instance of the game when a player is challenged by another player. We use <see cref="IUser"/> to store both player's Discord Name and Discord unique ID. 
        /// <see cref="ISocketMessageChannel"/> is passed in to make sure we display the results in the channel where the game was initated. 
        /// </summary>
        /// <param name="POne"></param>
        /// <param name="PTwo"></param>
        /// <param name="channel"></param>
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
        /// <summary>
        /// Adds a player to <see cref="RPSStaticGameLists.ActiveQueue"/> when queuing up for a random match.  
        /// </summary>
        /// <param name="player"></param>
        /// <param name="channel"></param>
       public void AddPlayerToQueue(IUser player, ISocketMessageChannel channel)
        {
            RPSStaticGameLists.ActiveQueue.Enqueue(PopulatePlayerObject(player));
        }
        /// <summary>
        /// Checks a player's entry. We do this by looping through the RPSStaticGameLists.ActiveGames list and only checking games at are currently active. 
        /// Once determined active we check if the users unique Discord ID exists, if so we add their choice to the RPSGameObject. 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="play"></param>
        /// <returns>
        /// RPSGameObject
        /// </returns>
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
        /// <summary>
        /// Checks the game object to see if both players have provided an answer. If they have, we start the logic to determine who won then store their stats. 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks the answers provided by both players to determine the winner. After a winner is decided we set a boolean inside <see cref="RPSGameObject"/> associated with the winning or losing player. 
        /// </summary>
        /// <param name=""="Game"></param>
        /// <see cref="RPSGameObject.POne"/>
        /// <see cref="RPSGameObject.PTwo"/>
        /// <returns></returns>
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
        /// <summary>
        /// Function that takes a Discord IUser Object and mutates the data into my own RPSPlayerGameObject. 
        /// </summary>
        /// <param name="user"></param>
        /// <see cref="RPSPlayerGameObject"/>
        /// <see cref="IUser"/>
        /// <returns></returns>
        public RPSPlayerGameObject PopulatePlayerObject(IUser user)
        {
            RPSPlayerGameObject Player = new RPSPlayerGameObject(user);

            return Player;
        }        
    }
}
