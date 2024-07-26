using System.Text;

namespace FullTextSearch.Model.DataStructure;

public class InvertedIndex
{
    public static List<InvertedIndex> InvertedIndicesList { get; }=new List<InvertedIndex>();
    public Dictionary<string, List<string>> InvertedIndexMap { get; init; }
    public string DirectoryPath { get; init; }
    public InvertedIndex(List<Document> documents,string directoryPath)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
        InvertedIndicesList.Add(this);
    }

    private Dictionary<string, List<string>>  BuildInvertedIndex(List<Document> documents)
    {
        return documents
            .SelectMany(doc => doc.Select(word => new { word, doc.DocName }))
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