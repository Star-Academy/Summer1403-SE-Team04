using FullTextSearch.Control.Reader;
using FullTextSearch.Model;
using FullTextSearch.Reader;

namespace FullTextSearch.Control.Logic.DocumentsLoader;

public class DocumentLoader
{
    private DocumentLoader()
    {
        
    }
    private static DocumentLoader? _docLoaderInstance;
    public static DocumentLoader DocumentLoaderInstance
    {
        get { return _docLoaderInstance ??= new DocumentLoader(); }
    }
    public List<Document> LoadDocumentsList(string directoryPath)
    {
        var documents = DocReader.DocReaderInstance.ReadDocs(directoryPath);
        return documents.EditWords();
    }

}