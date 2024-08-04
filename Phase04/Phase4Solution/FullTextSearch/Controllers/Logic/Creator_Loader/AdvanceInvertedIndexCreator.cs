using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCreator(IDocCatcher docCatcher,IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher,IDocumentLoader documentLoader) : IAdvancedInvertedIndexCreator
{
    public AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath)
    {
        var stringReformaters = new List<IStringReformater> { new ToLower(), new ToRoot() };
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, stringReformaters);
        var index = new AdvancedInvertedIndex(docCatcher.Load(), directoryPath);
        advancedInvertedIndexCatcher.Write(index);
        return index;
    }
}