using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class DocFinder : IFinder
{
    private static DocFinder _docFinder;

    private DocFinder()
    {
    }

    public static DocFinder Instance => _docFinder ??= new DocFinder();

    public IEnumerable<string>? Find(string query, InvertedIndex index)
    {
        var result = index.InvertedIndexMap.GetValueOrDefault(query);
        return result == null ? new List<string>() : result;
    }
}