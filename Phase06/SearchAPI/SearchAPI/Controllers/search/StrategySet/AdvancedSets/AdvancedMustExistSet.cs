using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;

namespace SearchAPI.Controllers.search.StrategySet.AdvancedSets;

public class AdvancedMustExistSet(string[] phrasesArray, IFinder finder) : IStrategySet
{
    public List<string> GetValidDocs()
    {
        var mustExistWords = phrasesArray.Where(phrase => !phrase.StartsWith('+') && !phrase.StartsWith('-'));

        return mustExistWords.Select(phrase => finder.Find(phrase).ToList())
            .ToList()
            .Intersect();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.AdvancedMustExist;
    }
}