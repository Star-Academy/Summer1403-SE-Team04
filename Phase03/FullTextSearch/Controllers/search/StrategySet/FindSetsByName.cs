using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;

namespace FullTextSearch.Controllers.search.StrategySet;

public static class FindSetsByName
{
    public static IStrategySet? FindByName(this IStrategySet[] strategies, StrategySetEnum name)
    {
        var result = strategies.FirstOrDefault(set => set.GetName() == name);
        if (result != null)
            return result;
        throw new StrategyNotFoundException();
    
    }
}