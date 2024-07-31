using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;

namespace FullTextSearch.Controllers.search;

public class QuerySearcher(IInvertedIndexCacher invertedIndexLoader) : IProcessor
{
    public void ProcessQuery(string query)
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(new TargetedStrategy(invertedIndex)).Search(query).ToList()).ToList();

        new OutputHandler(OutputRendererKeeper.Instance.OutputRenderer).SendOutput(result.Union());
    }
}