using FullTextSearch.Control.Logic;
using FullTextSearch.Control.search;
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
        return wordsArray.Where(word => word.StartsWith('-'))
            .Select(word => DocFinder.Instance.Find(word.Substring(1), index).ToList())
            .ToList().Union();
    }

    public string GetName()
    {
        return "MustNotExist";
    }
}