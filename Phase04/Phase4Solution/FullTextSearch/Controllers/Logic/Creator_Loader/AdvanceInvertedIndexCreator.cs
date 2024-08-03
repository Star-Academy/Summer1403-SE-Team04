using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class AdvanceInvertedIndexCreator(IDocCatcher docCatcher,IAdvancedInvertedIndexCatcher advancedInvertedIndexCatcher) : IAdvancedInvertedIndexCreator
{
    public void CreateAdvancedInvertedIndex(string directoryPath)
    {
        
    }
}