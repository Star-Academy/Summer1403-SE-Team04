using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class MustExistSet : IStrategySet
{
    private static MustExistSet _mustExistSet;
    public static MustExistSet Instance => _mustExistSet ??= new MustExistSet();
    private MustExistSet(){}
    public IEnumerable<string> GetValidDocs(string[] wordsArray , InvertedIndex index)
    {
        return wordsArray.Where(word => !word.StartsWith('+') && !word.StartsWith('-'))
            .Select(word => DocFinder.Instance.Find(word ,index).ToList())
            .ToList()
            .Intersect();
    }

    public StrategySetEnum GetName()
    {
        return StrategySetEnum.MustExist;
    }
}