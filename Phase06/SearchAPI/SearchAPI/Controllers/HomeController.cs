using FullTextSearch;
using SearchAPI.Controllers;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.Logic.Creator_Loader;
using SearchAPI.Controllers.Logic.DocumentsLoader;
using SearchAPI.Controllers.Reader;
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
    public List<string> Index(string query)
    {
        var docCatcher = new DocCatcher();
        var advIndexcatcher = new AdvanceInvertedIndexCatcher();
        var docLoader = new DocumentLoader(new DocBuilder(new TxtReader(), docCatcher), new SmallWordsRemover());
        var indicesList = new List<string> { Resources.DocumentsPath };
// var indexCreator = new InvertedIndexCreator(cacher, docLoader);
        new ServiceStartupInitializer(
            new AdvanceInvertedIndexCreator(docCatcher, advIndexcatcher, docLoader)).Init(indicesList);

       return new AdvancedQuerySearcher(advIndexcatcher, docCatcher).ProcessQuery(query);
    }
}