using System.Text;

namespace FullTextSearch;

public class InvertedIndex
{
    public Dictionary<string, List<string>> InvertedIndexMap { get; } = new Dictionary<string, List<string>>();

    public void 
        BuildInvertedIndex(List<Document> documents)
    {
        foreach (var doc in documents)
        {
            foreach (var word in doc.DocWords)
            {
                AddToDic(word,doc.DocName);
            }
        }
    }
    public void AddToDic(string key, string newDocName)
    {
        InvertedIndexMap.TryAdd(key, new List<string>());
        var docNames = InvertedIndexMap.GetValueOrDefault(key);
        if(!docNames.Contains(newDocName)) docNames.Add(newDocName);
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