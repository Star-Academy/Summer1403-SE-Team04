using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class StrategySetFactory : IStrategySetFactory
{
    private IReadOnlyDictionary<StrategySetEnum, IStrategySet> _strategySets;

    public void SetStrategySets(string[] wordsArray, InvertedIndex index)
    {
        _strategySets = new Dictionary<StrategySetEnum, IStrategySet>
        {
            {
                StrategySetEnum.MustExist, new MustExistSet(wordsArray, index)
            },
            {
                StrategySetEnum.MustNotExist, new MustNotExistSet(wordsArray, index)
            },
            {
                StrategySetEnum.AtLeastOneExist, new AtLeastOneExistSet(wordsArray, index)
            }
        };
    }

    public IStrategySet Create(StrategySetEnum setName)
    {
        return _strategySets.GetValueOrDefault(setName);
    }
}