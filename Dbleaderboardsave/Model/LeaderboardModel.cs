
using System.ComponentModel.DataAnnotations;


namespace Dbleaderboardsave.Model
{
    public class LeaderboardModel
    {
        //[Key]
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public float Version { get; set; }


    }
}
