using FullTextSearch.Control.Logic;
using FullTextSearch.Control.search;
using FullTextSearch.Control.search.SearchStrategy;
using FullTextSearch.Model.DataStructure;
using FullTextSearch.View.Cli;

namespace FullTextSearch.Control;

public class QuerySearcher
{
    private static QuerySearcher? _searcher;
    public static QuerySearcher Instance => _searcher ??= new QuerySearcher();

    public void ProcessQuery(string query)
    {
        var result = InvertedIndex.InvertedIndicesList.Select(invertedIndex =>
            new WordSearcher(invertedIndex, TargetedStrategy.Instance).Search(query).ToList()).ToList();
        
        OutputHandler.Instance.SendOutput(result.Union());
    }
}