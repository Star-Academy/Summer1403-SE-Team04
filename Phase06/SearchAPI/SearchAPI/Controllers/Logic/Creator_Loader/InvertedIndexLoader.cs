using System.Text.Json;
using SearchAPI;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class InvertedIndexCatcher : IInvertedIndexCatcher
{
    private static readonly string FilePath = Resources.InvertedIndexDataPath;

    private static readonly JsonSerializerOptions? Options = new()
    {
        IncludeFields = true
    };

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public List<InvertedIndex> InvertedIndices = new();

    public void Write(InvertedIndex index)
    {
        InvertedIndices.Add(index);
        File.WriteAllText(FilePath, "");
        var newJson = JsonSerializer.Serialize(InvertedIndices, WriteOptions);
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