using System.Text;
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
        
        var options = new JsonSerializerOptions
        {
            IncludeFields = true
        };
        
        var indices = json == string.Empty ? new List<InvertedIndex>() : JsonSerializer.Deserialize<List<InvertedIndex>>(json, options);

        indices.Add(index);
        
        var newOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        
        string newJson = JsonSerializer.Serialize(indices, newOptions);
        File.WriteAllText(filePath, newJson);
    }
}