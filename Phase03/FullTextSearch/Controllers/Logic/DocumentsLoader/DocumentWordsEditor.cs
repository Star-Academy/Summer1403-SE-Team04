using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public static class DocumentWordsEditor
{
    public static IEnumerable<Document> EditWords(this IEnumerable<Document> listOfDocuments,
        List<IStringReformater> reformaters)
    {
        return listOfDocuments.Select(doc => new Document(doc.DocName,
            doc.DocWords.FixWordsList(reformaters))).ToList();
    }
}