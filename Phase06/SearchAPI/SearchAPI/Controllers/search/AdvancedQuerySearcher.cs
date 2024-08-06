using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.SearchStrategy;

namespace SearchAPI.Controllers.search;

public class AdvancedQuerySearcher(IAdvancedInvertedIndexCatcher invertedIndexLoader, IDocCatcher docCatcher)
    : IAdvancedProcessor
{
    public List<string> ProcessQuery(string query)
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(
                    new AdvancedStrategy(new AdvancedDocFinder(invertedIndex, docCatcher, new SmallWordsRemover())))
                .Search(query).ToList()).ToList();
        return result.Union();
    }
}