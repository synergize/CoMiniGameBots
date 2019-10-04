using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.MiniGames.RockPaperScissors.Stats
{
    class PopulateStatObject
    {

        public List<RPSPlayerStatsDataModel> SetPlayerStats(List<RPSGameObject> listOfGames)
        {
            var listStats = new List<RPSPlayerStatsDataModel>();
            var activeGame = listOfGames.FindAll(x => x.IsActive == false);

            for (var i = 0; i < activeGame.Count; i++)
            {
                var game = activeGame[i];

                    var p1 = new RPSPlayerStatsDataModel
                    {
                        Stats = new RPSPlayerStatsDataModel.PlayerStats()
                    };
                    var p2 = new RPSPlayerStatsDataModel
                    {
                        Stats = new RPSPlayerStatsDataModel.PlayerStats()
                    };

                    p1 = SetPlayerInfo(game.POne, p1);
                    p1 = SetPlayerStatChoices(game.POne, p1);

                    if (!SetDraw(game))
                    {
                        p1 = SetWinLoss(game.POne, p1);
                        p2 = SetWinLoss(game.PTwo, p2);
                    }
                    else
                    {
                        p1.Stats.NumberDraws += 1;
                        p2.Stats.NumberDraws += 1;
                    }

                    p2 = SetPlayerInfo(game.PTwo, p2);
                    p2 = SetPlayerStatChoices(game.PTwo, p2);

                    listStats.Add(p1);
                    listStats.Add(p2);

                    RPSStaticGameLists.ActiveGames.Remove(game);
                

            }

            return listStats;
        }

        public RPSPlayerStatsDataModel ConvertToPlayerStatModel(RPSPlayerGameObject GameObj)
        {
            var stats = new RPSPlayerStatsDataModel
            {
                DiscordID = GameObj.User.Id,
                Name = GameObj.User.Username
            };
            return stats;
        }


        private RPSPlayerStatsDataModel SetPlayerStatChoices(RPSPlayerGameObject player, RPSPlayerStatsDataModel stats)
        {
            switch (player.Choice)
            {
                case "!scissors":
                    stats.Stats.NumberScissors += 1;
                    return stats;
                case "!paper":
                    stats.Stats.NumberPaper += 1;
                    return stats;
                case "!rock":
                    stats.Stats.NumberRocks += 1;
                    return stats;
                default:
                    return stats;
            }
        }

        private RPSPlayerStatsDataModel SetPlayerInfo(RPSPlayerGameObject player, RPSPlayerStatsDataModel stats)
        {
            stats.DiscordID = player.User.Id;
            stats.Name = player.User.Username;

            return stats;
        }

        private bool SetDraw(RPSGameObject player)
        {
            if (!player.POne.IsWinner && !player.PTwo.IsWinner)
            {
                return true;
            }

            return false;
        }

        private RPSPlayerStatsDataModel SetWinLoss(RPSPlayerGameObject player, RPSPlayerStatsDataModel stats)
        {
            if (player.IsWinner)
            {
                stats.Stats.NumberWins += 1;
            }
            else
            {
                stats.Stats.NumberLosses += 1;
            }

            return stats;
        }
    }
}
