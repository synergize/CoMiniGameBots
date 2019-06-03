using CoMiniGameBots.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiniGameBots.MiniGames.RockPaperScissors.Stats
{
    class PopulateStatObject
    {

        public List<RPSPlayerStatsDataModel> SetPlayerStats(List<RPSPlayerGameObject> ListOfPlayers)
        {            
            List<RPSPlayerStatsDataModel> ListStats = new List<RPSPlayerStatsDataModel>();
            RPSPlayerStatsDataModel Stats = new RPSPlayerStatsDataModel();
            Stats.Stats = new RPSPlayerStatsDataModel.PlayerStats();

            for (int i = 0; i < ListOfPlayers.Count; i++)
            {
                var Current = ListOfPlayers[i];
                Stats = SetPlayerInfo(Current, Stats);
                Stats = SetPlayerStatChoices(Current, Stats);
                ListStats.Add(Stats);
            }

            return ListStats;
        }
        public RPSPlayerStatsDataModel ConvertToPlayerStatModel(RPSPlayerGameObject GameObj)
        {
            RPSPlayerStatsDataModel Stats = new RPSPlayerStatsDataModel();
            //Stats = SetPlayerStatChoices(GameObj);
            Stats.DiscordID = GameObj.User.Id;
            Stats.Name = GameObj.User.Username;

            return Stats;
        }


        private RPSPlayerStatsDataModel SetPlayerStatChoices(RPSPlayerGameObject Player, RPSPlayerStatsDataModel Stats)
        {
            //RPSPlayerStatsDataModel.PlayerStats Stats = new RPSPlayerStatsDataModel.PlayerStats();

            switch (Player.Choice)
            {
                case "!shoot scissors":
                    Stats.Stats.NumberLosses += 1;
                    return Stats;
                case "!shoot paper":
                    Stats.Stats.NumberPaper += 1;
                    return Stats;
                case "!shoot rock":
                    Stats.Stats.NumberRocks += 1;
                    return Stats;
                default:
                    return Stats;
            }
        }
        private RPSPlayerStatsDataModel SetPlayerInfo(RPSPlayerGameObject Player, RPSPlayerStatsDataModel Stats)
        {
            Stats.DiscordID = Player.User.Id;
            Stats.Name = Player.User.Username;

            return Stats;
        }
    }
}
