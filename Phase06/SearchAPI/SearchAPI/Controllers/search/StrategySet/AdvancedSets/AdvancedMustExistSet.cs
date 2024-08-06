using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers.search.StrategySet.AdvancedSets;

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