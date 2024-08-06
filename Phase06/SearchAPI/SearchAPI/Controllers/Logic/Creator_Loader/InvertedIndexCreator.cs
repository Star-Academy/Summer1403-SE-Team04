using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class InvertedIndexCreator(IInvertedIndexCatcher catcher, IDocumentLoader documentLoader) : IInvertedIndexCreator
{
    public void CreateInvertedIndex(string directoryPath)
    {
        var stringReformaters = new List<IStringReformater> { new ToLower(), new ToRoot() };
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, stringReformaters);
        var newIndex = new InvertedIndex(documents, directoryPath);
        catcher.Write(newIndex);
    }
}