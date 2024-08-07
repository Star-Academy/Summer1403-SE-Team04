using FullTextSearch;
using SearchAPI.Controllers;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController(
    ILogger<HomeController> _logger,
    IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher,
    IDocCatcher docCatcher,
    IGarbageRemover garbageRemover)
    : Controller
{
    [HttpGet("{query}")]
    public IActionResult Index(string query)
    {
        if (String.IsNullOrEmpty(query)) return BadRequest();
        var a = new AdvancedQuerySearcher(advancedInvertedIndexCatcher, docCatcher, garbageRemover).ProcessQuery(query);
        if (!a.Any()) return NotFound();
        return null;
    }
}