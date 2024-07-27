using FullTextSearch.Control.search.StrategySet;
using FullTextSearch.Model;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Control.search.SearchStrategy;

public interface ISearchStrategy
{
    IEnumerable<string> Search(string query,InvertedIndex index);
}