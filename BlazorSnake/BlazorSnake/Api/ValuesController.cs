
using Dbleaderboardsave;
using Dbleaderboardsave.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorSnake.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {


        [HttpGet]
        public async Task<IEnumerable<LeaderboardModel>> Get([FromServices] IDatabasecore board , [FromQuery] float vers)
        {


            var x =  await board.GetScoreboard(vers);
           



            //List<LeaderboardModel> listpep = new List<LeaderboardModel>()
            //{
            //    new LeaderboardModel (){              
            //    Name = "test",
            //    Score = 1,
            //    Version = vers,
            //    },
            //    new LeaderboardModel()
            //    {                   
            //    Name = "test",
            //    Score = 2,
            //    Version = vers,
            //    }
            //};


            //var test = new LeaderboardModel()
            //{
            //    Id = 1,
            //    Name = "test",
            //    Score = 1,
            //    Version = 1,
            //};

            return x;
        }






        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
