using BlazorSnake.Client.Services;
using Dbleaderboardsave.Model;

public class ServerLeaderboardService : ILeaderboardService
{
    public async Task<ClientLeaderboardModel[]>? GetScore(string vers)
    {
        ClientLeaderboardModel[] client = [];

        return client;
    }
}