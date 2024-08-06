using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

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