using Microsoft.AspNetCore.Mvc;

namespace SearchAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Index([FromBody]string query)
    {
        
    }
}