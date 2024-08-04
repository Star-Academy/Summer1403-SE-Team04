using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCreator(IDocCatcher docCatcher,IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher,IDocumentLoader documentLoader) : IAdvancedInvertedIndexCreator
{
    public AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath)
    {
        new CreatDocList(documentLoader, docCatcher).CreatDoc(directoryPath);
        var index = new AdvancedInvertedIndex(docCatcher.Load(), directoryPath);
        advancedInvertedIndexCatcher.Write(index);
        return index;
    }
}