using SearchAPI;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers;

public class ServiceStartupInitializer(
    [FromServices]IAdvancedInvertedIndexCreator indexCreator
) : IInitializer
{
    public void Init(List<string> directoryList,List<IStringReformater> reformaters)
    {
        File.WriteAllText(Resources.AdvanceInverIndexPath, string.Empty);
        directoryList.ForEach(path => indexCreator.CreateAdvancedInvertedIndex(path,reformaters));
    }
}