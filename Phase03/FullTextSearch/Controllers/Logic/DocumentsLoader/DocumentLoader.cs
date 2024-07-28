using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public class DocumentLoader : IDocumentLoader
{
    private DocumentLoader()
    {
    }
    private static DocumentLoader? _docLoaderInstance;
    public static DocumentLoader Instance
    {
        get { return _docLoaderInstance ??= new DocumentLoader(); }
    }
    public IEnumerable<Document> LoadDocumentsList(IDocReader docReader,string directoryPath,List<IStringReformater> reformaters,IDocBuilder builder)
    {
        var documents = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                .Select(s => builder.Builed(s,docReader)).ToList();
        return documents.EditWords(reformaters);
    }

}