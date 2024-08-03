using System.Text.Json;
using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class InvertedIndexCatcher : IInvertedIndexCatcher
{
    public List<InvertedIndex> InvertedIndices = new List<InvertedIndex>();
    private static readonly string FilePath = Resources.InvertedIndexDataPath;

    private static readonly JsonSerializerOptions? Options = new()
    {
        IncludeFields = true
    };
    private static readonly JsonSerializerOptions ReadOptions = new()
    {
        IncludeFields = true
    };

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public void Write(InvertedIndex index)
    {
        InvertedIndices.Add(index);
        File.WriteAllText(FilePath, "");
        var json = File.ReadAllText(FilePath);
        var indices = json == string.Empty
            ? new List<InvertedIndex>()
            : JsonSerializer.Deserialize<List<InvertedIndex>>(json, ReadOptions);

        indices.Add(index);
        var newJson = JsonSerializer.Serialize(indices, WriteOptions);
        File.WriteAllText(FilePath, newJson);
    }

    public List<InvertedIndex>? Load()
    {
        return InvertedIndices;
    }

    public void LoadFromPath()
    {
        var json = File.ReadAllText(FilePath);
        InvertedIndices = JsonSerializer.Deserialize<List<InvertedIndex>>(json, Options).ToList();
    }
    
    
}