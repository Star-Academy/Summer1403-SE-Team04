using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search;

public class DocFinder(InvertedIndex index) : IBasicFinder
{
    public List<string>? Find(string word)
    {
        if (string.IsNullOrEmpty(word)) throw new NullOrEmptyQueryException();
        var result = index.InvertedIndexMap.GetValueOrDefault(word);
        return result == null ? new List<string>() : result;
    }
}