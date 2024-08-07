using System.Text.Json;
using SearchAPI;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCatcher : IAdvancedInvertedIndexCatcher
{
    private static readonly string FilePath = Resources.AdvanceInverIndexPath;

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    private List<AdvancedInvertedIndex> AdvanceInvertedIndices = new();

    public bool Write(AdvancedInvertedIndex index)
    {
        AdvanceInvertedIndices.Add(index);
        File.WriteAllText(FilePath, "");
        var newJson = JsonSerializer.Serialize(AdvanceInvertedIndices, WriteOptions);
        File.WriteAllText(FilePath, newJson);
        Console.WriteLine(this.GetHashCode());
        Console.WriteLine(AdvanceInvertedIndices.Count);
        return true;
    }

    public List<AdvancedInvertedIndex>? Load()
    {
        Console.WriteLine(AdvanceInvertedIndices.Count);
        return AdvanceInvertedIndices;
    }
}