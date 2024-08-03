using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet.AdvancedSets;

public class AdvancedAtLeastOneExistsSet(string[] phrasesArray, IAdvancedFinder finder) : IStrategySet
{
    public IEnumerable<string> GetValidDocs()
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