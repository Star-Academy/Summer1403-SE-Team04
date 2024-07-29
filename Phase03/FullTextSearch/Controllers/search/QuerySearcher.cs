using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearch.Controllers.search;

public class QuerySearcher(IInvertedIndexLoader? invertedIndexLoader) : IProcessor
{
    public void ProcessQuery(string query)
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(new TargetedStrategy(invertedIndex, new StrategySetFactory())).Search(query).ToList()).ToList();

        new OutputHandler(OutputRendererKeeper.Instance.OutputRenderer).SendOutput(result.Union());
    }
}