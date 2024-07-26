using FullTextSearch.Model;

namespace FullTextSearch.Control.Logic.DocumentsLoader;

public static class DocumentWordsEditor
{
    public static List<Document> EditWords(this List<Document> listOfDocuments)
    {
        return listOfDocuments.Select(doc => new Document(doc.DocName,
            doc.DocWords.FixWordsList())).ToList();
    }
}