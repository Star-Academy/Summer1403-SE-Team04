using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet.BasicSets;

namespace SearchAPI.Controllers.search.StrategySet;

public class StrategySetFactory
{
    private readonly IReadOnlyDictionary<StrategySetEnum, IStrategySet> _strategySets;

    public StrategySetFactory(string[] wordsArray, IFinder finder)
    {
        _strategySets = new Dictionary<StrategySetEnum, IStrategySet>
        {
            {
                StrategySetEnum.MustExist, new MustExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.MustNotExist, new MustNotExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.AtLeastOneExist, new AtLeastOneExistSet(wordsArray, finder)
            }
        };
    }

    public IStrategySet Create(StrategySetEnum setName)
    {
        return _strategySets.GetValueOrDefault(setName);
    }
}