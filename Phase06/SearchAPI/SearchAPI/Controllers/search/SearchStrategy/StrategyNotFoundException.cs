using FullTextSearch;

namespace SearchAPI.Controllers.search.SearchStrategy;

public class StrategyNotFoundException : Exception
{
    public StrategyNotFoundException() : base(Resources.StrategyExceptionMessage)
    {
    }
}