using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class QuerySearcher : IProcessor
{
    private static QuerySearcher? _searcher;
    public static QuerySearcher Instance => _searcher ??= new QuerySearcher();

    public void ProcessQuery(string query, IInvertedIndexLoader loader)
    {
        var result = loader.Load().Select(invertedIndex =>
            new WordSearcher(invertedIndex, TargetedStrategy.Instance).Search(query).ToList()).ToList();
        
        OutputHandler.Instance.SendOutput(result.Union());
    }
}