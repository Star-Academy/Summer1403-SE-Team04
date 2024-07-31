using System.Text.Json;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexWriter : IInvertedIndexWriter
{
    private static readonly string FilePath = Resources.InvertedIndexDataPath;

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
        File.WriteAllText(FilePath, "");
        var json = File.ReadAllText(FilePath);
        var indices = json == string.Empty
            ? new List<InvertedIndex>()
            : JsonSerializer.Deserialize<List<InvertedIndex>>(json, ReadOptions);

        indices.Add(index);
        var newJson = JsonSerializer.Serialize(indices, WriteOptions);
        File.WriteAllText(FilePath, newJson);
    }
}