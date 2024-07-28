using FullTextSearch.Control.Logic.DocumentsLoader;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controller.Logic;

public class InvertedIndexBuilder
{
    private static InvertedIndexBuilder? _indexBuilder;
    public static InvertedIndexBuilder InvertedIndexBuilderInstance => _indexBuilder ??= new InvertedIndexBuilder();
    public void BuildInvertedIndex(string directoryPath)
    {
        new InvertedIndex(DocumentLoader.DocumentLoaderInstance.LoadDocumentsList(directoryPath),directoryPath);
    }
}