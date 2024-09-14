using System.Text.Json;
using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCatcher : IAdvancedInvertedIndexCatcher
{
    private static readonly string FilePath = Resources.AdvanceInverIndexPath;

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public List<AdvancedInvertedIndex> AdvanceInvertedIndices = new();

    public bool Write(AdvancedInvertedIndex index)
    {
        AdvanceInvertedIndices.Add(index);
        File.WriteAllText(FilePath, "");
        var newJson = JsonSerializer.Serialize(AdvanceInvertedIndices, WriteOptions);
        File.WriteAllText(FilePath, newJson);
        return true;
    }

    public List<AdvancedInvertedIndex>? Load()
    {
        return AdvanceInvertedIndices;
    }
}