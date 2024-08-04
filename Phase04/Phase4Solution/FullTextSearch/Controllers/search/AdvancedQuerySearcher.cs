using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;

namespace FullTextSearch.Controllers.search;

public class AdvancedQuerySearcher(IAdvancedInvertedIndexCatcher invertedIndexLoader) : IAdvancedProcessor
{
    public void ProcessQuery(string query)
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(new AdvancedStrategy(new AdvancedDocFinder(invertedIndex, new DocCatcher(),new SmallWordsRemover()))).Search(query).ToList()).ToList();
        new OutputHandler(OutputRendererKeeper.Instance.OutputRenderer).SendOutput(result.Union());

    }
}