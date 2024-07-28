namespace FullTextSearch.Controllers.search.SearchStrategy;

public class StrategyNotFoundException : Exception
{ 
    public StrategyNotFoundException() : base("strategy not found pleas check your name")
    {
        
    }
}