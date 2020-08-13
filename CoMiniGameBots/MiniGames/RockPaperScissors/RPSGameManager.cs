using System;
using System.Collections.Generic;
using System.Diagnostics;
using CoMiniGameBots.Exceptions;
using CoMiniGameBots.MiniGames.RockPaperScissors.Stats;
using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using Discord;
using Discord.WebSocket;
using CoMiniGameBots.Extensions;

namespace CoMiniGameBots.MiniGames.RockPaperScissors
{
    internal class RpsGameManager
    {
        public static List<RpsGameObject> ActiveGames { get; set; } = new List<RpsGameObject>();

        /// <summary>
        /// Kicks off an instance of the game when a player is challenged by another player. We use <see cref="IUser"/> to store both player's Discord Name and Discord unique ID. 
        /// <see cref="ISocketMessageChannel"/> is passed in to make sure we display the results in the channel where the game was initated. 
        /// </summary>
        /// <param name="POne"></param>
        /// <param name="PTwo"></param>
        /// <param name="channel"></param>
        public void GameRunChallenge(IUser POne, IUser PTwo, ISocketMessageChannel channel)
        {

            var activeGame = new RpsGameObject(PopulatePlayerObject(POne), PopulatePlayerObject(PTwo), channel)
                .InitializeGame();
        }

        ///// <summary>
        ///// Adds a player to <see cref="RpsStaticGameLists.ActiveQueue"/> when queuing up for a random match.  
        ///// </summary>
        ///// <param name="player"></param>
        ///// <param name="channel"></param>
        //public void AddPlayerToQueue(IUser player, ISocketMessageChannel channel)
        //{
        //    RpsStaticGameLists.ActiveQueue.Enqueue(PopulatePlayerObject(player));
        //}

        /// <summary>
        /// Checks a player's entry. We do this by looping through the RPSStaticGameLists.ActiveGames list and only checking games at are currently active. 
        /// Once determined active we check if the users unique Discord ID exists, if so we add their choice to the RPSGameObject. 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="play"></param>
        /// <returns>
        /// RPSGameObject
        /// </returns>
        public RpsGameObject GetPlayerEntry(IUser user, string play)
        {
            var currentEntry = ActiveGames.Find(x => x.POne.User.Id == user.Id || x.PTwo.User.Id == user.Id);

            if (currentEntry.POne.User.Id == user.Id && currentEntry.POne.Choice == null)
            {
                currentEntry.POne.Choice = play;
                return IsWinner(currentEntry);
            }
            if (currentEntry.PTwo.User.Id == user.Id && currentEntry.PTwo.Choice == null)
            {
                currentEntry.PTwo.Choice = play;
                return IsWinner(currentEntry);
            }
            return null;
        }

        /// <summary>
        /// Checks the game object to see if both players have provided an answer. If they have, we start the logic to determine who won then store their stats. 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private static RpsGameObject IsWinner(RpsGameObject game)
        {
            if (game.PTwo.Choice != null && game.POne.Choice != null)
            {
                var save = new StatJsonController();
                var populate = new PopulateStatObject();
                var winner = DetermineWinner(game);
                winner.RemoveGame();
                save.SaveStatsJson(populate.SetPlayerStats(winner));
                return winner;
            }
            return game;
            
        }

        /// <summary>
        /// Checks the answers provided by both players to determine the winner. After a winner is decided we set a boolean inside <see cref="RpsGameObject"/> associated with the winning or losing player. 
        /// </summary>
        /// <see cref="RpsGameObject.POne"/>
        /// <see cref="RpsGameObject.PTwo"/>
        /// <returns></returns>
        private static RpsGameObject DetermineWinner(RpsGameObject game)
        {
            if (game.POne.Choice == game.PTwo.Choice)
            {
                game.POne.IsWinner = false;
                game.PTwo.IsWinner = false;
                return game;
            }
            if (game.POne.Choice == "!scissors" && game.PTwo.Choice == "!paper" ||
                game.POne.Choice == "!paper" && game.PTwo.Choice == "!rock" ||
                game.POne.Choice == "!rock" && game.PTwo.Choice == "!scissors")
            {
                game.POne.IsWinner = true;
                return game;
            }

            game.PTwo.IsWinner = true;
            return game;
        }

        /// <summary>
        /// Function that takes a Discord IUser Object and mutates the data into my own RPSPlayerGameObject. 
        /// </summary>
        /// <param name="user"></param>
        /// <see cref="RpsPlayerGameObject"/>
        /// <see cref="IUser"/>
        /// <returns></returns>
        public RpsPlayerGameObject PopulatePlayerObject(IUser user)
        {
            var player = new RpsPlayerGameObject(user);

            return player;
        }

        /// <summary>
        /// Boolean function that returns if the player is already in an active game. Currently only allowing a player to queue up for one game at a time.
        /// There is logic in here to remove the instance of a game if a game went "stale" after 5 minutes. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool CheckIfPlayerPlaying(IUser player)
        {
            var isPlaying = false;
            var p1Game = ActiveGames.Find(x => x.POne.User == player);
            var p2Game = ActiveGames.Find(x => x.PTwo.User == player);

            if (p1Game != null)
            {
                isPlaying = true;
            }

            if (p2Game != null)
            {
                isPlaying = true;
            }
            return isPlaying;
        }

        public static void DetermineAndRemoveInactiveGames(IUser opponent, IUser challenger)
        {
            var p1Game = ActiveGames.Find(x => x.POne.User == opponent || x.PTwo.User == opponent);

            if (p1Game != null)
            {
                RemoveInactiveGame(p1Game, challenger);
            }
        }

        public static void RemoveInactiveGame(RpsGameObject game, IUser challenger)
        {
            var idleGameDuration = new TimeSpan(0, 0, 5, 0);
            var expirationTime = game.StartTime.Add(idleGameDuration);
            var timeLeft = expirationTime.Subtract(DateTime.UtcNow);

            if (expirationTime <= DateTime.UtcNow)
            {
                game.RemoveGame();
                throw new GameExpiredException($"There was a mighty battle between {game.POne.User.Username} and {game.PTwo.User.Username}, but it has expired. {challenger.Mention}, challenge your opponent again!");
            }

            throw new GameNotExpiredException($"{game.POne.User.Username} and {game.PTwo.User.Username} are battling it out. Their game started at {game.StartTime:hh:mm:ss} UTC, it will expire in {timeLeft.Minutes} minutes and {timeLeft.Seconds} seconds or if someone wins.");
        }
    }
}
