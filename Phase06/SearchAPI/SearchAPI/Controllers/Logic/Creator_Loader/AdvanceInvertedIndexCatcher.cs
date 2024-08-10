using System.Text.Json;
using SearchAPI;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Model.Database;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCatcher(FullTextSearchDbContext context) : IAdvancedInvertedIndexCatcher
{
    private static readonly string FilePath = Resources.AdvanceInverIndexPath;

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public bool Write(AdvancedInvertedIndex index)
    {
        try
        {
            var DirectoryPath = index.DirectoryPath;
            var DicJson = JsonSerializer.Serialize(index.InvertedIndexMap, WriteOptions);
            context.Add(new InvertedIndexDataStore() { DirectoryPath = DirectoryPath, DicJson = DicJson });
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<AdvancedInvertedIndex>? Load()
    {
        return context.InvertedIndexDataStores.Select(i => new AdvancedInvertedIndex(i)).ToList();
    }
}