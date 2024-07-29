using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;

namespace FullTextSearch.Controllers.search;

public class QuerySearcher(IInvertedIndexLoader invertedIndexLoader) : IProcessor
{
    public void ProcessQuery(string query)
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(new TargetedStrategy(invertedIndex)).Search(query).ToList()).ToList();

        OutputHandler.Instance.SendOutput(result.Union());
    }
}