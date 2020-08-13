using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoMiniGameBots.MiniGames.RockPaperScissors.Stats
{
    public class StatJsonController
    {
        public void SaveStatsJson(List<RpsPlayerStatsDataModel> ListStats)
        {
            try
            {
                foreach (var item in ListStats)
                {
                    var filePath = FilePaths.BuildFilePath($"{item.DiscordId}.json");
                    var readFile = ReadStatsJson(item.DiscordId);
                    if (readFile == null)
                    {
                        using (var file = File.CreateText(filePath))
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
                        using (var file = File.CreateText(filePath))
                        {
                            var serializer = new JsonSerializer
                            {
                                Formatting = Formatting.Indented
                            };
                            serializer.Serialize(file, UpdateStatsJson(readFile, item));
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

        public RpsPlayerStatsDataModel ReadStatsJson(ulong DiscordId)
        {
            var filePath = FilePaths.BuildFilePath($"{DiscordId}.json");
            if (CheckFileExists(filePath))
            {
                var obj = JsonConvert.DeserializeObject<RpsPlayerStatsDataModel>(File.ReadAllText(filePath));

                return obj;
            }
            else
            {
                return null;
            }
        }

        private static bool CheckFileExists(string FilePath)
        {
            var newDir = FilePaths.DataDirectory;
            if (!Directory.Exists(newDir))
            {
                Directory.CreateDirectory(newDir);
            }
            if (!File.Exists(FilePath))
            {
                var steamIdJson = File.Create(FilePath);
                steamIdJson.Close();
                return false;
            }
            else
            {
                return true;
            }            
        }

        private static RpsPlayerStatsDataModel UpdateStatsJson(RpsPlayerStatsDataModel InfoFromFile, RpsPlayerStatsDataModel NewInfo)
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
