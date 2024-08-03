namespace FullTextSearch.Model.DataStructure;

public class AdvancedInvertedIndex
{
    public Dictionary<string, IEnumerable<DocumentWordsStorage>> InvertedIndexMap { get; init; }
    public string DirectoryPath { get; init; }
    
    public AdvancedInvertedIndex(IEnumerable<Document> documents, string directoryPath)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
    }
    
    private Dictionary<string, IEnumerable<DocumentWordsStorage>> BuildInvertedIndex(IEnumerable<Document> documents)
    {
        var map = documents
            .SelectMany(doc => doc.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => new DocumentWordsStorage(x.DocName, new List<int>())).Distinct());
    }
}