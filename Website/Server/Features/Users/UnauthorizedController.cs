using Microsoft.AspNetCore.Mvc;

namespace Website.Server;

[Route("unauthorized")]
public class UnauthorizedController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Unauthorized();
    }
}