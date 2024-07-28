namespace FullTextSearch.Controllers.search.SearchStrategy;

public class StrategyNotFoundException : Exception
{ 
    public StrategyNotFoundException() : base(Resources.StrategyExceptionMessage)
    {
        
    }
}