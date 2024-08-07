using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.StrategySet.BasicSets;

public class MustNotExistSet(string[] wordsArray,AdvancedInvertedIndex invertedIndex, IFinder finder) : IStrategySet
{
    public List<string> GetValidDocs()
    {
        var mustNotExistWords = wordsArray.Where(word => word.StartsWith('-')).Select(word => word.Substring(1));
        return mustNotExistWords.Select(word => finder.Find(invertedIndex, word).ToList())
            .ToList().Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustNotExist;
    }
}