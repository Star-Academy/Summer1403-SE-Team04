
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.search.Abstraction;

namespace SearchAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController([FromServices] IAdvancedProcessor advancedQuerySearcher) : Controller
{
    [HttpGet("{query}")]
    public IActionResult Index(string query)
    {
        if (String.IsNullOrEmpty(query)) return BadRequest();
        var a = advancedQuerySearcher.ProcessQuery(query);
        if (!a.Any()) return NotFound();
        return Ok();
    }
}