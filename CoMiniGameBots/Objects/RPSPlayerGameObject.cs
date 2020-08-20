using Discord;

namespace CoMiniGameBots.Objects
{
    public class RpsPlayerGameObject
    {
        private IUser GuildUser { get; }

        public RpsPlayerGameObject(IUser user, string entry = null)
        {
            GuildUser = user;
            Choice = entry;

        }
        public string Choice { get; set; }
        public int InProgressWins { get; set; }

        public IUser User => GuildUser;

        public bool IsWinner { get; set; } = false;
    }
}
