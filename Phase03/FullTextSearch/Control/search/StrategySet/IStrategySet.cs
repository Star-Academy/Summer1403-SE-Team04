using System.Collections;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Control.search.StrategySet;

public interface IStrategySet
{
    IEnumerable<string> GetValidDocs(string[] wordsArray, InvertedIndex index);
    string GetName();
}