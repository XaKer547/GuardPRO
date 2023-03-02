using Microsoft.AspNetCore.Mvc;

namespace GuardPRO.API.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("api/test")]
    public int ReturnRandom()
    {
        var random = new Random();
        return random.Next(100);
    }
}
