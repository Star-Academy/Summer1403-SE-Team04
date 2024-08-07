using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.StrategySet.BasicSets;

public class MustExistSet(string[] wordsArray,AdvancedInvertedIndex invertedIndex, IFinder finder) : IStrategySet
{

    public List<string> GetValidDocs()
    {
        var mustExistWords = wordsArray.Where(word => !word.StartsWith('+') && !word.StartsWith('-'));

        return mustExistWords.Select(word => finder.Find(invertedIndex, word).ToList())
            .ToList()
            .Intersect();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustExist;
    }
}