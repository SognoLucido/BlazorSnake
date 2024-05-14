namespace BlazorSnake.Services
{
    public interface IScoreboard
    {

        int Score {  get; }
       void AddtoScore(int valor);
    }
}
