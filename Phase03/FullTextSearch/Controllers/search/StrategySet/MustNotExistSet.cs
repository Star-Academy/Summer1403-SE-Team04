using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class MustNotExistSet(string[] wordsArray, InvertedIndex index) : IStrategySet
{
    public IEnumerable<string> GetValidDocs()
    {
        var mustNotExistWords = wordsArray.Where(word => word.StartsWith('-')).Select(word => word.Substring(1));
        return mustNotExistWords.Select(word => new DocFinder(index).Find(word).ToList())
            .ToList().Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustNotExist;
    }
}