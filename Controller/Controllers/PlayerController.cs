using Microsoft.AspNetCore.Mvc;
using Model;
namespace Controller;

[ApiController]
[Route("player")]
public class PlayerController: ControllerBase
{
    [HttpGet]
    [Route("Login")]
    public int VerifyLogin([FromBody] Player player)
    {
        using (var context = new Context())
        {
            var result = context.Players.FirstOrDefault(p => p.Name == player.Name && p.Password == player.Password);
            if (result != null)
            {
                return result.Id;
            }
            else
            {
                return -1;
            }
        }
    }

    [HttpPost]
    [Route("register")]
    public int RegisterPlayer([FromBody] Player player)
    {
        var id = player.save();
        return id;
    }
}