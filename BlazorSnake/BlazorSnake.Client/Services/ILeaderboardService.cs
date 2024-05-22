using Dbleaderboardsave.Model;

namespace BlazorSnake.Client.Services
{
    public interface ILeaderboardService
    {
        Task<ClientLeaderboardModel[]>? GetScore(string vers);
    }
}
