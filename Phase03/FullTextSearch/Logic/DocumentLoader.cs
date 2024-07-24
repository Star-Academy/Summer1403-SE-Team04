using FullTextSearch.Model;
using FullTextSearch.Reader;

namespace FullTextSearch.Logic;

public class DocumentLoader
{
    private DocumentLoader()
    {
        
    }
    private static DocumentLoader _docLoaderInstance;
    public static DocumentLoader DocumentLoaderInstance
    {
        get { return _docLoaderInstance ??= new DocumentLoader(); }
    }
    public List<Document> LoadDocuments()
    {
        return EditDocumentWords(DocReader.DocReaderInstance.ReadDocs());
    }

    private List<Document> EditDocumentWords(List<Document> listOfDocuments)
    {
        return listOfDocuments.Select(doc => new Document(doc.DocName,
            WordsFormatFixer(doc.DocWords))).ToList();
    }

    private List<string> WordsFormatFixer(List<string> documentWords)
    {
        return documentWords.Select(w => w.FixWordFormat())
            .ToList().RemoveEmptyCells();
    }
}