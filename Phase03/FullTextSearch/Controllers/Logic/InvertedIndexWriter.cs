using System.Text.Json;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexWriter : IInvertedIndexWriter
{
    public void Write(InvertedIndex index)
    {
        string filePath = Resources.InvertedIndexDataPath;
        string json = File.ReadAllText(filePath); 
        var indices = json == string.Empty ? new List<InvertedIndex>() : JsonSerializer.Deserialize<List<InvertedIndex>>(json);

        indices.Add(index);
        string newJson = JsonSerializer.Serialize(indices);
        File.WriteAllText(filePath, newJson);
    }
}