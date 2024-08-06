using FullTextSearch;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers;

public class ServiceStartupInitializer(
    IAdvancedInvertedIndexCreator indexCreator
) : IInitializer
{
    public void Init(List<string> directoryList)
    {
        File.WriteAllText(Resources.AdvanceInverIndexPath, string.Empty);
        directoryList.ForEach(path => indexCreator.CreateAdvancedInvertedIndex(path));
    }
}