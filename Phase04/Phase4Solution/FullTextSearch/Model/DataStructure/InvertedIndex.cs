using System.Text;
using System.Text.Json.Serialization;

namespace FullTextSearch.Model.DataStructure;

public class InvertedIndex
{
    [JsonConstructor]
    public InvertedIndex(Dictionary<string, List<string>> invertedIndexMap, string directoryPath)
    {
        InvertedIndexMap = invertedIndexMap;
        DirectoryPath = directoryPath;
    }

    public InvertedIndex(List<Document> documents, string directoryPath)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
    }

    [JsonInclude] public Dictionary<string, List<string>> InvertedIndexMap { get; private set; }

    [JsonInclude] public string DirectoryPath { get; private set; }

    private Dictionary<string, List<string>> BuildInvertedIndex(List<Document> documents)
    {
        return documents
            .SelectMany(doc => doc.DocWords.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.DocName).Distinct().ToList());
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Inverted Index:");
        foreach (var kvp in InvertedIndexMap) sb.AppendLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        return sb.ToString();
    }
}