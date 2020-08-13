using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;
using CoMiniGameBots.Static_Data;

namespace CoMiniGameBots.Extensions
{
    public static class RpsGameExtensions
    {
        public static RpsGameObject InitializeGame(this RpsGameObject game)
        {
            RpsGameManager.ActiveGames.Add(game);
            return game;
        }

        public static void RemoveGame(this RpsGameObject game)
        {
            RpsGameManager.ActiveGames.Remove(game);
        }
    }
}
