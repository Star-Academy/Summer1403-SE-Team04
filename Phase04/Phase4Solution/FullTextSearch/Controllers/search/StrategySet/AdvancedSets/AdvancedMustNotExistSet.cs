using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet.AdvancedSets;


public class AdvancedMustNotExistSet(string[] phrasesArray, IFinder finder) : IStrategySet
{
    public IEnumerable<string> GetValidDocs()
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