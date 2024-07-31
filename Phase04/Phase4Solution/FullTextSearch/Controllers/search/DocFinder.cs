using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class DocFinder(InvertedIndex index) : IFinder
{
    public IEnumerable<string>? Find(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        var result = index.InvertedIndexMap.GetValueOrDefault(query);
        return result == null ? new List<string>() : result;
    }
}