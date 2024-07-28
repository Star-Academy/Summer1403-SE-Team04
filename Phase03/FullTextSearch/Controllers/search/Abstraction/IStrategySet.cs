using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface IStrategySet
{
    IEnumerable<string> GetValidDocs(string[] wordsArray, InvertedIndex index);
    string GetName();
}