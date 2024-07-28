using FullTextSearch.Control.Reader;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public class DocumentLoader : IDocumentLoader
{
    private DocumentLoader()
    {
    }
    private static DocumentLoader? _docLoaderInstance;
    public static DocumentLoader DocumentLoaderInstance
    {
        get { return _docLoaderInstance ??= new DocumentLoader(); }
    }
    public IEnumerable<Document> LoadDocumentsList(string directoryPath)
    {
        var documents = DocReader.DocReaderInstance.ReadDocs(directoryPath);
        return documents.EditWords();
    }

}