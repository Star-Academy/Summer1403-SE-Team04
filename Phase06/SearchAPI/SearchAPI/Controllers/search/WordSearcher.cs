using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet;

namespace SearchAPI.Controllers.search;

public class WordSearcher(ISearchStrategy strategy) : ISearchAble
{
    public List<string> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        return strategy.Search(query);
    }
}