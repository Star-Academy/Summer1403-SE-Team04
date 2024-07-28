using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    private static InvertedIndexBuilder? _indexBuilder;
    public static InvertedIndexBuilder InvertedIndexBuilderInstance => _indexBuilder ??= new InvertedIndexBuilder();
    public void BuildInvertedIndex(string directoryPath, IInvertedIndexWriter writer,IDocumentLoader documentLoader)
    {
        new InvertedIndex(documentLoader.LoadDocumentsList(
            DocReader.DocReaderInstance,directoryPath,
            new List<IStringReformater>(){ToLower.Instance,new ToRoot()},
            DocBuilder.Instance)
            ,directoryPath, writer);
    }
}