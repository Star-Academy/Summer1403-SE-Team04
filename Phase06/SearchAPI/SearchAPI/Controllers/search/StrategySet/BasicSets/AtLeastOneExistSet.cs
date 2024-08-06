using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.search.Abstraction;

namespace SearchAPI.Controllers.search.StrategySet.BasicSets;

public class AtLeastOneExistSet(string[] wordsArray, IFinder finder) : IStrategySet
{
    public List<string> GetValidDocs()
    {
        var atLeastOneExistsWords = wordsArray.Where(word => word.StartsWith('+'))
            .Select(word => word.Substring(1));

        return atLeastOneExistsWords
            .Select(word => finder.Find(word).ToList())
            .ToList()
            .Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.AtLeastOneExist;
    }
}