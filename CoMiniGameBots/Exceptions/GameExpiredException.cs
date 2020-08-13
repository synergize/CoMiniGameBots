using System;

namespace CoMiniGameBots.Exceptions
{
    public class GameExpiredException : Exception
    {
        public GameExpiredException()
        {

        }

        public GameExpiredException(string message) : base(message)
        {

        }

        public GameExpiredException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
