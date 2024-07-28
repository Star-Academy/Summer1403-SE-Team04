using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class MustNotExistSet : IStrategySet
{
    private static MustNotExistSet _mustNotExistSet;
    public static MustNotExistSet Instance => _mustNotExistSet ??= new MustNotExistSet();
    private MustNotExistSet(){}
    public IEnumerable<string> GetValidDocs(string[] wordsArray , InvertedIndex index)
    {
        var mustNotExistWords = wordsArray.Where(word => word.StartsWith('-')).Select(word => word.Substring(1));
        return mustNotExistWords.Select(word => DocFinder.Instance.Find(word, index).ToList())
            .ToList().Union();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustNotExist;
    }
}