using System.Text.Json;
using SearchAPI;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Model.Database;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCatcher(FullTextSearchDbContext context) : IAdvancedInvertedIndexCatcher
{
    private static readonly string FilePath = Resources.AdvanceInverIndexPath;

    public bool Write(AdvancedInvertedIndex index)
    {
        try
        {
            context.Add(new InvertedIndexDataStore(index));
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