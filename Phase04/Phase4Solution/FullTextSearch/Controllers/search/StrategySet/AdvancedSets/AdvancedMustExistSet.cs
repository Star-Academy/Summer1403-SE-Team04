using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet.AdvancedSets;


public class AdvancedMustExistSet(string[] phrasesArray, IFinder finder) : IStrategySet
{
    public IEnumerable<string> GetValidDocs()
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