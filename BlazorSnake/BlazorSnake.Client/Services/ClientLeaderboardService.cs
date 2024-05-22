using Dbleaderboardsave.Model;
using System.Net.Http.Json;

namespace BlazorSnake.Client.Services
{
    public class ClientLeaderboardService(HttpClient http) : ILeaderboardService
    {


        public Task<ClientLeaderboardModel[]> GetScore(string vers) => http.GetFromJsonAsync <ClientLeaderboardModel[]>($"api/Leaderboard?vers={vers}")!;

    }
}
