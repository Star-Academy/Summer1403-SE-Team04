using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCatcher : IAdvancedInvertedIndexCatcher
{
    public List<AdvancedInvertedIndex> AdvanceInvertedIndices = new List<AdvancedInvertedIndex>();
    private static readonly string FilePath = Resources.InvertedIndexDataPath;
    public void Write(AdvancedInvertedIndex index)
    {
        throw new NotImplementedException();
    }

    public List<AdvancedInvertedIndex>? Load()
    {
        return AdvanceInvertedIndices;
    }
}