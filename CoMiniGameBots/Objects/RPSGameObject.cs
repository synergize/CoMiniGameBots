using Discord.WebSocket;
using System;
using CoMiniGameBots.Extensions;

namespace CoMiniGameBots.Objects
{
    public class RpsGameObject
    {
        public RpsGameObject(RpsPlayerGameObject P1, RpsPlayerGameObject P2, ISocketMessageChannel channel)
        {
            POne = P1;
            PTwo = P2;
            GameChannel = channel;
            StartTime = DateTime.UtcNow;
            IsRandom = false;
        }

        public RpsGameObject(RpsPlayerGameObject P1, RpsPlayerGameObject P2)
        {
            POne = P1;
            PTwo = P2;
            StartTime = DateTime.UtcNow;
            IsRandom = true;
        }

        public RpsPlayerGameObject POne { get; }
        public RpsPlayerGameObject PTwo { get; }
        public ISocketMessageChannel GameChannel { get; }

        public DateTime StartTime { get; }

        public bool IsRandom { get; }

        public RpsGameObject AddActiveGame(RpsGameObject game)
        {
            return game.InitializeGame();
        }

        public static void ConcludeGame(RpsGameObject game)
        {
            game.RemoveGame();
        }
    }
}
