using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;

namespace SearchAPI.Controllers.search.StrategySet.AdvancedSets;

public class AdvancedAtLeastOneExistsSet(string[] phrasesArray, IFinder finder) : IStrategySet
{
    public List<string> GetValidDocs()
    {
        var atLeastOneExistsPhrases = phrasesArray.Where(phrase => phrase.StartsWith('+'))
            .Select(phrase => phrase.Substring(1));

        return atLeastOneExistsPhrases
            .Select(phrase => finder.Find(phrase).ToList())
            .ToList()
            .Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.AdvancedAtLeastOneExist;
    }
}