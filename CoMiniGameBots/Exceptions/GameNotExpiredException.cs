using System;

namespace CoMiniGameBots.Exceptions
{
    public class GameNotExpiredException : Exception
    {
        public GameNotExpiredException()
        {

        }

        public GameNotExpiredException(string message) : base(message)
        {

        }

        public GameNotExpiredException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
