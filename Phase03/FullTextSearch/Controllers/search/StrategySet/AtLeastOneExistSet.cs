using FullTextSearch.Control.Logic;
using FullTextSearch.Control.search;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class AtLeastOneExistSet : IStrategySet
{
    private static AtLeastOneExistSet _atLeastOneExistSet;
    public static AtLeastOneExistSet Instance => _atLeastOneExistSet ??= new AtLeastOneExistSet();
    private AtLeastOneExistSet(){}
    public IEnumerable<string> GetValidDocs(string[] wordsArray,InvertedIndex index)
    {
        return wordsArray.Where(word => word.StartsWith('+'))
            .Select(word => DocFinder.Instance.Find(word.Substring(1),index).ToList())
            .ToList()
            .Union();
    }

    public string GetName()
    {
        return "AtLeastOneExists";
    }
}