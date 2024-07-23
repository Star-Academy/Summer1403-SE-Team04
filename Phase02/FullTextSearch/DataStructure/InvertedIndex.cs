using System.Text;

namespace FullTextSearch;

public class InvertedIndex
{
    public Dictionary<string, List<string>> InvertedIndexMap { get; set; } = new Dictionary<string, List<string>>();

    public InvertedIndex(List<Document> documents)
    {
        InvertedIndexMap = documents
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