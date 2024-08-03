namespace FullTextSearch.Model.DataStructure;

public class DocumentWordsStorage
{
    public string DocumentName { get; init; }
    public IEnumerable<int> WordOccurences { get; set; }

    public DocumentWordsStorage(string documentName, IEnumerable<int> wordOccurences)
    {
        DocumentName = documentName;
        WordOccurences = wordOccurences;
    }
}