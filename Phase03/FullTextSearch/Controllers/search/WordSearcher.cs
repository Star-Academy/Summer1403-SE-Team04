using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class WordSearcher(InvertedIndex invertedIndex, ISearchStrategy strategy) : ISearchAble
{
    public IEnumerable<string> Search(string query)
    {
        return strategy.Search(query, invertedIndex);
    }
}