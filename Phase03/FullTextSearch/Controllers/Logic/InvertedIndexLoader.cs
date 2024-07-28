using System.Text.Json;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexLoader : IInvertedIndexLoader
{
    public List<InvertedIndex> Load()
    {
        var filePath = Resources.InvertedIndexDataPath;
        var json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            IncludeFields = true
        };

        return JsonSerializer.Deserialize<List<InvertedIndex>>(json, options);
    }
}