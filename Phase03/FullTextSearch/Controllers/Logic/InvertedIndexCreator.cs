using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexCreator : IInvertedIndexCreator
{
    private static InvertedIndexCreator? _indexCreator;
    public static InvertedIndexCreator InvertedIndexCreatorInstance => _indexCreator ??= new InvertedIndexCreator();

    public void CreateInvertedIndex(string directoryPath, IInvertedIndexWriter writer, IDocumentLoader documentLoader)
    {
        var stringReformaters = new List<IStringReformater> { ToLower.Instance, new ToRoot() };
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, stringReformaters);

        var newIndex = new InvertedIndex(documents, directoryPath);
        writer.Write(newIndex);
    }
}