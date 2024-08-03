using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet.BasicSets;


public class MustExistSet(string[] wordsArray, InvertedIndex index) : IStrategySet
{
    public IEnumerable<string> GetValidDocs()
    {
        var mustExistWords = wordsArray.Where(word => !word.StartsWith('+') && !word.StartsWith('-'));

        return mustExistWords.Select(word => new DocFinder(index).Find(word).ToList())
            .ToList()
            .Intersect();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustExist;
    }
}