using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;

namespace SearchAPI.Controllers.search.StrategySet.AdvancedSets;

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