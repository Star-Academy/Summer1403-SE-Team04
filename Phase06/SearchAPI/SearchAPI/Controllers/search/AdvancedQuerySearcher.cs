using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.SearchStrategy;

namespace SearchAPI.Controllers.search;

public class AdvancedQuerySearcher([FromServices] IAdvancedInvertedIndexCatcher invertedIndexCatcher, [FromServices] IDocCatcher documentCacher,[FromServices] IGarbageRemover remover)
    : IAdvancedProcessor
{
    public List<string> ProcessQuery(string query)
    {
        var result = invertedIndexCatcher.Load().Select(invertedIndex =>
            new WordSearcher(
                    new AdvancedStrategy(new AdvancedDocFinder(invertedIndex, documentCacher, remover)))
                .Search(query).ToList()).ToList();
        return result.Union();
    }
}