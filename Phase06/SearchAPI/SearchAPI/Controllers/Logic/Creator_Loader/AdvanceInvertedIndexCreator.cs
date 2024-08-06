using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCreator(
    IDocCatcher docCatcher,
    IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher,
    IDocumentLoader documentLoader) : IAdvancedInvertedIndexCreator
{
    public AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath)
    {
        new CreatDocList(documentLoader, docCatcher).CreatDoc(directoryPath);
        var index = new AdvancedInvertedIndex(docCatcher.Load(), directoryPath);
        advancedInvertedIndexCatcher.Write(index);
        return index;
    }
}