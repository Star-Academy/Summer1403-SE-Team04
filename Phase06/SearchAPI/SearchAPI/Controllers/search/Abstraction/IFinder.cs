using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.Abstraction;

public interface IFinder
{
    List<string>? Find(AdvancedInvertedIndex index, string word);
}