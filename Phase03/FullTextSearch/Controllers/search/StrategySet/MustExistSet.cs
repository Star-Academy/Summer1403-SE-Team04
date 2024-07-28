using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class MustExistSet : IStrategySet
{
    private static MustExistSet _mustExistSet;

    private MustExistSet()
    {
    }

    public static MustExistSet Instance => _mustExistSet ??= new MustExistSet();

    public IEnumerable<string> GetValidDocs(string[] wordsArray, InvertedIndex index)
    {
        var mustExistWords = wordsArray.Where(word => !word.StartsWith('+') && !word.StartsWith('-'));

        return mustExistWords.Select(word => DocFinder.Instance.Find(word, index).ToList())
            .ToList()
            .Intersect();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustExist;
    }
}