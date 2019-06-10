using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoMiniGameBots.MiniGames.RockPaperScissors.Stats
{
    public class StatJsonController
    {
        public void SaveStatsJson(List<RPSPlayerStatsDataModel> ListStats)
        {
            try
            {
                foreach (var item in ListStats)
                {
                    string FilePath = FilePaths.BuildFilePath($"{item.DiscordID}.json");
                    var ReadFile = ReadStatsJson(item.DiscordID);
                    if (ReadFile == null)
                    {
                        using (StreamWriter file = File.CreateText(FilePath))
                        {
                            var serializer = new JsonSerializer
                            {
                                Formatting = Formatting.Indented
                            };
                            serializer.Serialize(file, item);
                        }
                    }
                    else
                    {
                        using (StreamWriter file = File.CreateText(FilePath))
                        {
                            PopulateStatObject Convert = new PopulateStatObject();
                            var serializer = new JsonSerializer
                            {
                                Formatting = Formatting.Indented
                            };
                            serializer.Serialize(file, UpdateStatsJson(ReadFile, item));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public RPSPlayerStatsDataModel ReadStatsJson(ulong DiscordID)
        {
            RPSPlayerStatsDataModel obj = new RPSPlayerStatsDataModel();
            string FilePath = FilePaths.BuildFilePath($"{DiscordID}.json");
            if (CheckFileExists(FilePath))
            {
                obj = JsonConvert.DeserializeObject<RPSPlayerStatsDataModel>(File.ReadAllText(FilePath));

                return obj;
            }
            else
            {
                return null;
            }
        }
        private bool CheckFileExists(string FilePath)
        {
            string newDir = FilePaths.DataDirectory;
            if (!Directory.Exists(newDir))
            {
                DirectoryInfo dir = Directory.CreateDirectory(newDir);
            }
            if (!File.Exists(FilePath))
            {
                var SteamIDJson = File.Create(FilePath);
                SteamIDJson.Close();
                return false;
            }
            else
            {
                return true;
            }            
        }
        private RPSPlayerStatsDataModel UpdateStatsJson(RPSPlayerStatsDataModel InfoFromFile, RPSPlayerStatsDataModel NewInfo)
        {
            InfoFromFile.Name = NewInfo.Name;
            InfoFromFile.Stats.NumberLosses += NewInfo.Stats.NumberLosses;
            InfoFromFile.Stats.NumberPaper += NewInfo.Stats.NumberPaper;
            InfoFromFile.Stats.NumberRocks += NewInfo.Stats.NumberRocks;
            InfoFromFile.Stats.NumberScissors += NewInfo.Stats.NumberScissors;
            InfoFromFile.Stats.NumberWins += NewInfo.Stats.NumberWins;
            InfoFromFile.Stats.NumberDraws += NewInfo.Stats.NumberDraws;

            return InfoFromFile;
        }

    }
}
