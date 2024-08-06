using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers.search.StrategySet.AdvancedSets;

public class AdvancedMustNotExistSet(string[] phrasesArray, IFinder finder) : IStrategySet
{
    public List<string> GetValidDocs()
    {
        var mustNotExistWords = phrasesArray
            .Where(phrase => phrase.StartsWith('-')).Select(phrase => phrase.Substring(1));
        return mustNotExistWords.Select(phrase => finder.Find(phrase).ToList())
            .ToList().Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.AdvancedMustNotExist;
    }
}