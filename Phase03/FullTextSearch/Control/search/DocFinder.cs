using System.Runtime.InteropServices;
using FullTextSearch.Control.Reader;
using FullTextSearch.Control.search.SearchStrategy;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Control.search;

public class DocFinder
{
    private static DocFinder _docFinder;
    public static DocFinder Instance => _docFinder ??= new DocFinder();
    private DocFinder(){}
    public IEnumerable<string>? Find(string query,InvertedIndex index)
    {
        return index.InvertedIndexMap.GetValueOrDefault(query);
    }
}