using SearchAPI.Controllers.search.StrategySet;

namespace SearchAPI.Controllers.search.Abstraction;

public interface IStrategySet
{
    List<string> GetValidDocs();
    StrategySetEnum GetName();
}