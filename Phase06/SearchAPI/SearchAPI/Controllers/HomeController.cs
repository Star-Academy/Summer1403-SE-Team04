using FullTextSearch;
using SearchAPI.Controllers;
using SearchAPI.Controllers.Logic;

using SearchAPI.Controllers.search;
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

    [HttpGet("{query}")]
    public ActionResult<List<string>> Index(string query)
    {
        if (String.IsNullOrEmpty(query)) return BadRequest();
        // var a = new AdvancedQuerySearcher(advIndexcatcher, docCatcher).ProcessQuery(query);
        // if (!a.Any()) return NotFound();
        return null;
    }
}