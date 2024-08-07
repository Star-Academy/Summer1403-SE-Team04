using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.SearchStrategy;

namespace SearchAPI.Controllers.search;

public class QuerySearcher(IInvertedIndexCatcher invertedIndexLoader) //: IBasicProcessor
{
    /*public List<string> ProcessQuery(string query)
    {
        var result = invertedIndexLoader.Load().Select(invertedIndex =>
            new WordSearcher(new TargetedStrategy(new DocFinder(invertedIndex), new List<IStringReformater>() { new ToLower(), new ToRoot()})).Search(query).ToList()).ToList();
        return result.Union();
    }*/
}