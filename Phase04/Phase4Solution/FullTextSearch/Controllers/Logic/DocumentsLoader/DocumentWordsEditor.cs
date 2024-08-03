using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public static class DocumentWordsEditor
{
    public static IEnumerable<Document> EditWords(this IEnumerable<Document> listOfDocuments,
        List<IStringReformater> reformaters, IGarbageRemover remover)
    {
        if (reformaters is null || reformaters.Count == 0) return listOfDocuments;
        return listOfDocuments.Select(doc => new Document(doc.DocName,
            remover.Remove(doc.DocWords.FixWordsList(reformaters)))).ToList();
    }
}