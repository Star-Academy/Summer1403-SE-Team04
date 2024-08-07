using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.Abstraction;

public interface IBasicFinder : IFinder
{
    List<string>? Find(AdvancedInvertedIndex invertedIndex,string word);
}