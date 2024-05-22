

using Dbleaderboardsave.Model;

namespace Dbleaderboardsave
{
    public interface IDatabasecore
    {
        public Task<IEnumerable<LeaderboardModel>> GetScoreboard(float vers);
        public Task InsertTo(LeaderboardModel model);
       

    }
}
