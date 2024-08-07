using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet.AdvancedSets;
using SearchAPI.Controllers.search.StrategySet.BasicSets;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.StrategySet;

public class AdvancedStrategySetFactory
{
    private readonly IReadOnlyDictionary<StrategySetEnum, IStrategySet> _strategySets;

    public AdvancedStrategySetFactory(string[] wordsArray,AdvancedInvertedIndex invertedIndex, IFinder finder)
    {
        _strategySets = new Dictionary<StrategySetEnum, IStrategySet>
        {
            {
                StrategySetEnum.AdvancedMustExist, new AdvancedMustExistSet(wordsArray,invertedIndex, finder)
            },
            {
                StrategySetEnum.AdvancedMustNotExist, new AdvancedMustNotExistSet(wordsArray,invertedIndex, finder)
            },
            {
                StrategySetEnum.AdvancedAtLeastOneExist, new AdvancedAtLeastOneExistsSet(wordsArray,invertedIndex, finder)
            }
        };
    }

    public IStrategySet Create(StrategySetEnum setName)
    {
        return _strategySets.GetValueOrDefault(setName);
    }
}