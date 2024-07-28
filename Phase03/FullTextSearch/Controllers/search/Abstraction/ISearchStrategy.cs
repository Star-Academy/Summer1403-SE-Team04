using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface ISearchStrategy 
{
    IEnumerable<string> Search(string query,InvertedIndex index);
}