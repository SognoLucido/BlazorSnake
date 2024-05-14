namespace BlazorSnake.Services
{
    public class Scoreboard : IScoreboard
    {
        public int Score { get; private set; } = 0;




        public void AddtoScore(int valor)
        {
            Score += valor;
        }


    }
}
