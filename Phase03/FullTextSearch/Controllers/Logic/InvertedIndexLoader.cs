using System.Text.Json;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexLoader : IInvertedIndexLoader
{
    private static readonly string FilePath = Resources.InvertedIndexDataPath;

    private static readonly JsonSerializerOptions? Options = new()
    {
        IncludeFields = true
    };

    public List<InvertedIndex>? Load()
    {
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<InvertedIndex>>(json, Options);
    }
}