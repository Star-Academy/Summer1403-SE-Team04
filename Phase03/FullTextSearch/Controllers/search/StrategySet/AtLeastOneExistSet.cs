using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class AtLeastOneExistSet : IStrategySet
{
    private static AtLeastOneExistSet _atLeastOneExistSet;

    private AtLeastOneExistSet()
    {
    }

    public static AtLeastOneExistSet Instance => _atLeastOneExistSet ??= new AtLeastOneExistSet();

    public IEnumerable<string> GetValidDocs(string[] wordsArray, InvertedIndex index)
    {
        var atLeastOneExistsWords = wordsArray.Where(word => word.StartsWith('+'))
            .Select(word => word.Substring(1));

        return atLeastOneExistsWords
            .Select(word => DocFinder.Instance.Find(word, index).ToList())
            .ToList()
            .Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.AtLeastOneExist;
    }
}