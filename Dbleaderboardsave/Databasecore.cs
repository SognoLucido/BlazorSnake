
using Dapper;
using Dbleaderboardsave.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace Dbleaderboardsave;

public class Databasecore : IDatabasecore
{

    private readonly IConfiguration _configuration;

    public Databasecore(IConfiguration configuration)
    {
        _configuration = configuration;
    }




    public async Task<IEnumerable<LeaderboardModel>> GetScoreboard(float vers)
    {
        var sql = "SELECT Name,Score,Version FROM Scoreboard WHERE Version = @Version  ";


        using (var conn = new SQLiteConnection(_configuration.GetConnectionString("Sqlite")))
        {


            //var x =  conn.Query<LeaderboardModel>(sql, new {Version = vers}).ToList();

            return await conn.QueryAsync<LeaderboardModel>(sql, new { Version = vers }).ConfigureAwait(false);

            //List<LeaderboardModel> scores = x.ToList();

        }

        //List<LeaderboardModel> result = new();

        //return result;
    }

    public async Task InsertTo(LeaderboardModel model)
    {


        try { 

            using (var conn = new SQLiteConnection(_configuration.GetConnectionString("Sqlite")))
            {
                var sql = "INSERT INTO Scoreboard (Name, Score, Version) VALUES ( @Name, @Score, @Version)";

                conn.Execute(sql, model);

            }
        }
        catch (Exception ex)
        {

        }

    }




}