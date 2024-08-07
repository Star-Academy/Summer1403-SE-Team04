using System.Text.Json;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Model.Database;

public class InvertedIndexDataStore
{
    public string DirectoryPath { get; set; }
    public string DicJson { get; set; }

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public InvertedIndexDataStore(AdvancedInvertedIndex advancedInvertedIndex)
    {
        DirectoryPath = advancedInvertedIndex.DirectoryPath;
        DicJson = JsonSerializer.Serialize(advancedInvertedIndex.InvertedIndexMap, WriteOptions);   
    }
}