using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet.AdvancedSets;
using SearchAPI.Controllers.search.StrategySet.BasicSets;

namespace SearchAPI.Controllers.search.StrategySet;

public class AdvancedStrategySetFactory
{
    private readonly IReadOnlyDictionary<StrategySetEnum, IStrategySet> _strategySets;

    public AdvancedStrategySetFactory(string[] wordsArray, IFinder finder)
    {
        _strategySets = new Dictionary<StrategySetEnum, IStrategySet>
        {
            {
                StrategySetEnum.AtLeastOneExist, new AtLeastOneExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.AdvancedMustExist, new AdvancedMustExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.AdvancedMustNotExist, new AdvancedMustNotExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.AdvancedAtLeastOneExist, new AdvancedAtLeastOneExistsSet(wordsArray, finder)
            }
        };
    }

    public IStrategySet Create(StrategySetEnum setName)
    {
        return _strategySets.GetValueOrDefault(setName);
    }
}