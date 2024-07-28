
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;
public static class DocumentWordsEditor
{
    public static IEnumerable<Document> EditWords(this IEnumerable<Document> listOfDocuments)
    {
        return listOfDocuments.Select(doc => new Document(doc.DocName,
            doc.DocWords.FixWordsList(new SmallWordsRemover()))).ToList();
    }
}