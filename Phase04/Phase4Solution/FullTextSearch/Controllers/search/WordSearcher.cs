using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearch.Controllers.search;

public class WordSearcher(ISearchStrategy strategy) : ISearchAble
{
    public IEnumerable<string> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        return strategy.Search(query);
    }
}