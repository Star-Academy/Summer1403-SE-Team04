using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers.search;

public class AdvancedQuerySearcher(IAdvancedInvertedIndexCatcher invertedIndexLoader) : IAdvancedProcessor
{
    public void ProcessQuery(string query)
    {
        
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(new AdvancedStrategy(invertedIndex)).Search(query).ToList()).ToList();

        new OutputHandler(OutputRendererKeeper.Instance.OutputRenderer).SendOutput(result.Union());

    }
}