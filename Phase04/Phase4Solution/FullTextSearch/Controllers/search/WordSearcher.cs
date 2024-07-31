using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers.search;

public class WordSearcher(ISearchStrategy strategy) : ISearchAble
{
    public IEnumerable<string> Search(string query)
    {
        return strategy.Search(query);
    }
}