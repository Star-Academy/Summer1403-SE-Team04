using FullTextSearch.Model.Abstraction;

namespace FullTextSearch.Model.DataStructure;

public class DocumentWordsStorage : IWordInformation
{
    public string DocumentName { get; init; }

    public IEnumerable<int> WordOccurences;
    public DocumentWordsStorage(string documentName, IEnumerable<int> wordOccurences)
    {
        DocumentName = documentName;
        WordOccurences = wordOccurences;
    }

    public string GetDocumentName()
    {
        return DocumentName;
    }

    public IEnumerable<int> GetWordOccurences()
    {
        return WordOccurences;
    }

    public void AddWordOccurences(int index)
    {
        WordOccurences.Append(index);
    }
}