using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IAdvancedInvertedIndexCreator
{
    AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath, List<IStringReformater> reformaters);
}