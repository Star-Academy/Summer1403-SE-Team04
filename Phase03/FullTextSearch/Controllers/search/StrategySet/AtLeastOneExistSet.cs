using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class AtLeastOneExistSet(string[] wordsArray, InvertedIndex index) : IStrategySet
{ 
    public IEnumerable<string> GetValidDocs()
    {
        var atLeastOneExistsWords = wordsArray.Where(word => word.StartsWith('+'))
            .Select(word => word.Substring(1));

        return atLeastOneExistsWords
            .Select(word => new DocFinder(index).Find(word).ToList())
            .ToList()
            .Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.AtLeastOneExist;
    }
}