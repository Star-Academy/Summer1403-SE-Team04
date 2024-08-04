using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface IStrategySet
{
    List<string> GetValidDocs();
    StrategySetEnum GetName();
}