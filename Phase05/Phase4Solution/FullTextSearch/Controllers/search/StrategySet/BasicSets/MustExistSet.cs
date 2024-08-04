using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers.search.StrategySet.BasicSets;

public class MustExistSet(string[] wordsArray, IFinder finder) : IStrategySet
{
    public List<string> GetValidDocs()
    {
        var mustExistWords = wordsArray.Where(word => !word.StartsWith('+') && !word.StartsWith('-'));

        return mustExistWords.Select(word => finder.Find(word).ToList())
            .ToList()
            .Intersect();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustExist;
    }
}