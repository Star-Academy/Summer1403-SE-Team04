using System.Runtime.Versioning;
using System.Text.Json;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic;

public class InvertedIndexLoader : IInvertedIndexLoader
{
    public List<InvertedIndex> Load()
    {
        string filePath = Resources.InvertedIndexDataPath;
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<InvertedIndex>>(json);
    }
}