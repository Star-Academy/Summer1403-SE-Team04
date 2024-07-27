using FullTextSearch.Control.search.SearchStrategy;

namespace FullTextSearch.Control.search.StrategySet;

public static class FindSetsByName
{
    public static IStrategySet? FindByName(this IStrategySet[] sets,string name)
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