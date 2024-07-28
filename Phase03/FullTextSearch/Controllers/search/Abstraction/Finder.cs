using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface Finder
{
    public IEnumerable<string>? Find(string query, InvertedIndex index);

}