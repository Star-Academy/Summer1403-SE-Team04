using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface IStrategySet
{
    IEnumerable<string> GetValidDocs();
    StrategySetEnum GetName();
}