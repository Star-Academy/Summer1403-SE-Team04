using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCreator(
    [FromServices] IDocCatcher docCatcher,
    [FromServices] IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher,
    [FromServices] IDocumentLoader documentLoader) : IAdvancedInvertedIndexCreator
{
    public AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath, List<IStringReformater> reformaters)
    {
        new CreatDocList(documentLoader).CreatDoc(directoryPath,reformaters);
        var index = new AdvancedInvertedIndex(docCatcher.Load(), directoryPath);
        advancedInvertedIndexCatcher.Write(index);
        return index;
    }
}