using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class DocFinder(InvertedIndex index) : IBasicFinder
{
    public List<string>? Find(string word)
    {
        if (string.IsNullOrEmpty(word)) throw new NullOrEmptyQueryException();
        var result = index.InvertedIndexMap.GetValueOrDefault(word);
        return result == null ? new List<string>() : result;
    }
}