using CoMiniGameBots.Objects;
using System.Collections.Generic;

namespace CoMiniGameBots.MiniGames.RockPaperScissors.Stats
{
    internal class PopulateStatObject
    {

        public List<RpsPlayerStatsDataModel> SetPlayerStats(RpsGameObject concludedGame)
        {
            var listStats = new List<RpsPlayerStatsDataModel>();
            var p1 = new RpsPlayerStatsDataModel
            {
                Stats = new RpsPlayerStatsDataModel.PlayerStats()
            };

            var p2 = new RpsPlayerStatsDataModel
            {
                Stats = new RpsPlayerStatsDataModel.PlayerStats()
            };

            p1 = SetPlayerInfo(concludedGame.POne, p1);
            p1 = SetPlayerStatChoices(concludedGame.POne, p1);

            if (!SetDraw(concludedGame))
            {
                p1 = SetWinLoss(concludedGame.POne, p1);
                p2 = SetWinLoss(concludedGame.PTwo, p2);
            }
            else
            {
                p1.Stats.NumberDraws += 1;
                p2.Stats.NumberDraws += 1;
            }

            p2 = SetPlayerInfo(concludedGame.PTwo, p2);
            p2 = SetPlayerStatChoices(concludedGame.PTwo, p2);

            listStats.Add(p1);
            listStats.Add(p2);

            return listStats;
        }

        public RpsPlayerStatsDataModel ConvertToPlayerStatModel(RpsPlayerGameObject GameObj)
        {
            var stats = new RpsPlayerStatsDataModel
            {
                DiscordId = GameObj.User.Id,
                Name = GameObj.User.Username
            };
            return stats;
        }


        private static RpsPlayerStatsDataModel SetPlayerStatChoices(RpsPlayerGameObject player, RpsPlayerStatsDataModel stats)
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

        private static RpsPlayerStatsDataModel SetPlayerInfo(RpsPlayerGameObject player, RpsPlayerStatsDataModel stats)
        {
            stats.DiscordId = player.User.Id;
            stats.Name = player.User.Username;

            return stats;
        }

        private static bool SetDraw(RpsGameObject player)
        {
            return !player.POne.IsWinner && !player.PTwo.IsWinner;
        }

        private static RpsPlayerStatsDataModel SetWinLoss(RpsPlayerGameObject player, RpsPlayerStatsDataModel stats)
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
