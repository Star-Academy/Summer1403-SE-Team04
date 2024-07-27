namespace FullTextSearch.Control.search.StrategySet;

public static class FindSetsByName
{
    public static IStrategySet? FindByName(this IStrategySet[] sets,string name)
    {
        return sets.FirstOrDefault(set => set.GetName() == name);
    }
}