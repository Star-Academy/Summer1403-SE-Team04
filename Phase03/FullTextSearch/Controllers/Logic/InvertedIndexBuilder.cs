using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    private static InvertedIndexBuilder? _indexBuilder;
    public static InvertedIndexBuilder InvertedIndexBuilderInstance => _indexBuilder ??= new InvertedIndexBuilder();
    public void BuildInvertedIndex(string directoryPath)
    {
        new InvertedIndex(DocumentLoader.DocumentLoaderInstance.LoadDocumentsList(directoryPath),directoryPath);
    }
}