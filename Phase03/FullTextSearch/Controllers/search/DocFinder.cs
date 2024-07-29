using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class DocFinder(InvertedIndex index) : IFinder
{ 
    public IEnumerable<string>? Find(string query)
    {
        var result = index.InvertedIndexMap.GetValueOrDefault(query);
        return result == null ? new List<string>() : result;
    }
}