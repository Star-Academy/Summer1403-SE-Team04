using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IAdvancedInvertedIndexCreator
{
    AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath);
}