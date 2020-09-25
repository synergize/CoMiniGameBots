using System.Runtime.InteropServices;
using CoMiniGameBots.MiniGames.RockPaperScissors;
using CoMiniGameBots.Objects;

namespace CoMiniGameBots.Extensions
{
    public static class RpsGameExtensions
    {
        public static RpsGameObject InitializeGame(this RpsGameObject game)
        {
            RpsGameManager.ActiveGames.TryAdd(game.POne.User.Id, game);
            return game;
        }

        public static void RemoveGame(this RpsGameObject game)
        {
            RpsGameManager.ActiveGames.TryRemove(game.PTwo.User.Id, out var removedGameObject);
        }
    }
}
