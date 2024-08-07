using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search;

public class WordSearcher(ISearchStrategy strategy) : ISearchAble
{
    public List<string> Search(string query,AdvancedInvertedIndex invertedIndex)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        return strategy.Search(query,invertedIndex);
    }
}