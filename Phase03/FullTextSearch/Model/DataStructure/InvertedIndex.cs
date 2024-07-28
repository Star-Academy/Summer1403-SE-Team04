using System.Collections;
using System.Text;
using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Model.DataStructure;

public class InvertedIndex
{
    public Dictionary<string, IEnumerable<string>> InvertedIndexMap { get; init; }
    public string DirectoryPath { get; init; }
    public InvertedIndex(IEnumerable<Document> documents,string directoryPath, IInvertedIndexWriter writer)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
        writer.Write(this);
    }

    private Dictionary<string, IEnumerable<string>>  BuildInvertedIndex(IEnumerable<Document> documents)
    {
        return documents
            .SelectMany(doc => doc.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.DocName).Distinct())
            ;    
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