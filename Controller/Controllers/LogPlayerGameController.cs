using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controller;

[ApiController]
[Route("log")]
public class LogPlayerGameController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public int LogPlayerGame([FromBody] LogPlayerGame logPlayerGame)
    {
        var id = logPlayerGame.save();
        return id;
    }

    [HttpGet]
    [Route("top10-{gameId}")]
    public object Top10Score(int gameId){
        Console.Write(gameId);
       var response =  Model.LogPlayerGame.Top10Score(gameId);
         return response;
    }
}