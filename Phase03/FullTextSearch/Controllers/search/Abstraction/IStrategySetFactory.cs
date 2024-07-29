using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface IStrategySetFactory
{
    IStrategySet Create(StrategySetEnum setName);
    void SetStrategySets(string[] wordsArray, InvertedIndex index);
}