using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;

namespace FullTextSearch.Controllers.search.StrategySet;

public static class FindSetsByName
{
    public static IStrategySet? FindByName(this IStrategySet[] sets,StrategySetEnum name)
    {
        try
        {
            var result = sets.FirstOrDefault(set => set.GetName() == name);
            if (result!=null)
            {
                return result;
            }
            else
            {
                throw new StrategyNotFoundException();
            }
        }
        catch (StrategyNotFoundException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}