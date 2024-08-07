using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.Abstraction;

public interface ISearchAble
{
    List<string> Search(string query,AdvancedInvertedIndex invertedIndex);
}