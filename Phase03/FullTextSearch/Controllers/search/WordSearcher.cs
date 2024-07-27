using System.Collections;
using FullTextSearch.Control.search.SearchStrategy;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Control.search;

public class WordSearcher(InvertedIndex invertedIndex, ISearchStrategy strategy)
{
    public IEnumerable<string> Search( string query)
    {
        return strategy.Search(query, invertedIndex);
    }
}