using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCreator(IDocCatcher docCatcher,IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher) : IAdvancedInvertedIndexCreator
{
    public AdvancedInvertedIndex CreateAdvancedInvertedIndex(string directoryPath)
    {
        var index = new AdvancedInvertedIndex(docCatcher.Load(), directoryPath);
        advancedInvertedIndexCatcher.Write(index);
        return index;
    }
}