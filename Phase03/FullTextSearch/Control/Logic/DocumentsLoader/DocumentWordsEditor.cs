using FullTextSearch.Model;

namespace FullTextSearch.Control.Logic.DocumentsLoader;

public class DocumentWordsEditor
{
    private DocumentWordsEditor()
    {
    }
    private static DocumentWordsEditor? _docWordsEditorInstance;
    public static DocumentWordsEditor DocumentWordsEditorInstance => _docWordsEditorInstance ??= new DocumentWordsEditor();

    public List<Document> EditWords(List<Document> listOfDocuments)
    {
        return listOfDocuments.Select(doc => new Document(doc.DocName,
            WordsFormatFixer.WordsFormatFixerInstance.FixWords(doc.DocWords))).ToList();
    }
}