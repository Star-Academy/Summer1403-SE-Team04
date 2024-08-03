using FullTextSearch.Model.Abstraction;

namespace FullTextSearch.Model.DataStructure;

public class AdvancedInvertedIndex
{
    public Dictionary<string, IEnumerable<IWordInformation>> InvertedIndexMap { get; init; }
    public string DirectoryPath { get; init; }
    
    public AdvancedInvertedIndex(IEnumerable<Document> documents, string directoryPath)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
    }
    private Dictionary<string, IEnumerable<IWordInformation>> BuildInvertedIndex(IEnumerable<Document> documents)
    {
        return documents
            .SelectMany(doc => doc.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => (IWordInformation) new DocumentWordsStorage(x.DocName, new List<int>())).Distinct());
    }
}