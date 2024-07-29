using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexCreator(InvertedIndexWriter writer,IDocumentLoader documentLoader) : IInvertedIndexCreator
{ 
    public void CreateInvertedIndex(string directoryPath)
    {
        var stringReformaters = new List<IStringReformater> { new ToLower(), new ToRoot() };
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, stringReformaters);

        var newIndex = new InvertedIndex(documents, directoryPath);
        writer.Write(newIndex);
    }
}