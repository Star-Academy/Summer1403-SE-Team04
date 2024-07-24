namespace FullTextSearch;

public class DocumentLoader
{
    public List<Document> LoadDocuments()
    {
        return editDocumentWords(new DocReader().ReadDocs());
    }

    private List<Document> editDocumentWords(List<Document> listOfDocuments)
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