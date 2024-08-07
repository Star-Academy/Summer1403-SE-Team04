using SearchAPI;

namespace SearchAPI.Controllers.search.StrategySet;

public class NullOrEmptyQueryException : Exception
{
    public NullOrEmptyQueryException() : base(Resources.NullOrEmptyQueryExceptionMessage)
    {
    }
}