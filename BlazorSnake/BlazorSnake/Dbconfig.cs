using Dapper;
using Dbleaderboardsave.Model;
using System.Data.SQLite;

namespace BlazorSnake
{


    public static class DbseedExtensions
    {

        public static IApplicationBuilder UseDbstartconfig(this IApplicationBuilder app, IConfiguration conf)
        {

            try
            {

                using (var conn = new SQLiteConnection(conf.GetConnectionString("Sqlite")))
                {


                    conn.Open();

                    var sql = @"SELECT * FROM Scoreboard";

                    var x = conn.QueryFirstOrDefault<LeaderboardModel>(sql);

                  
                }

            }
            catch(SQLiteException ex) 
            { 

                if (ex.Message.Contains("table"))
                {
                    using var conn = new SQLiteConnection(conf.GetConnectionString("Sqlite"));

                    conn.Execute(
                   @"CREATE TABLE [Scoreboard] (
                               [Id]	INTEGER NOT NULL,
                               [Name]  TEXT NOT NULL,
                               [Score]	INTEGER NOT NULL,
                               [Version] REAL NOT NULL,
                           PRIMARY KEY([Id] AUTOINCREMENT)
                          );");

                }
                else{
                  Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
              
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }





            return app;

        }


           
    }

}



