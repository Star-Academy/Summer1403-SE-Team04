using FullTextSearch.Model.AbstractClass;

namespace FullTextSearch.Model.DataStructure;

public class AdvancedInvertedIndex
{
    public Dictionary<string, IEnumerable<DocInformation>> InvertedIndexMap { get; init; }
    public string DirectoryPath { get; init; }
    
    public AdvancedInvertedIndex(IEnumerable<Document> documents, string directoryPath)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
    }
    public AdvancedInvertedIndex(Dictionary<string, IEnumerable<DocInformation>> invertedIndexMap, string directoryPath)
    {
        InvertedIndexMap = invertedIndexMap;
        DirectoryPath = directoryPath;
    }
    private Dictionary<string, IEnumerable<DocInformation>> BuildInvertedIndex(IEnumerable<Document> documents)
    {
        return documents
            .SelectMany(doc => doc.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x =>(DocInformation) new DocumentDocsStorage(x.DocName, new List<int>())).Distinct());
    }
}