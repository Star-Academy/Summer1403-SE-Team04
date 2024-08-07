using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.SearchStrategy;

namespace SearchAPI.Controllers.search;

public class AdvancedQuerySearcher([FromServices]ISearchStrategy searchStrategy,[FromServices] IAdvancedInvertedIndexCatcher invertedIndexLoader)
    : IAdvancedProcessor
{
    public List<string> ProcessQuery(string query) 
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(searchStrategy).Search(query, invertedIndex)).ToList();
        return result.Union();
    }
}