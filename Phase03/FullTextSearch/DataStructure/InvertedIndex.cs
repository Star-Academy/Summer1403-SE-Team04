using System.Text;
using FullTextSearch.Model;

namespace FullTextSearch.DataStructure;

public class InvertedIndex
{
    public Dictionary<string, List<string>> InvertedIndexMap { get; init; }

    public InvertedIndex(List<Document> documents)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
    }

    private Dictionary<string, List<string>>  BuildInvertedIndex(List<Document> documents)
    {
        return documents
            .SelectMany(doc => doc.DocWords.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.DocName).Distinct().ToList()
            );    
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Inverted Index:");
        foreach (var kvp in InvertedIndexMap)
        {
            sb.AppendLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
        return sb.ToString();
    }

}