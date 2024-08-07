using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet.BasicSets;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search.StrategySet;

public class StrategySetFactory
{
    private readonly IReadOnlyDictionary<StrategySetEnum, IStrategySet> _strategySets;

    public StrategySetFactory(string[] wordsArray,AdvancedInvertedIndex invertedIndex, IFinder finder)
    {
        _strategySets = new Dictionary<StrategySetEnum, IStrategySet>
        {
            {
                StrategySetEnum.MustExist, new MustExistSet(wordsArray,invertedIndex, finder)
            },
            {
                StrategySetEnum.MustNotExist, new MustNotExistSet(wordsArray,invertedIndex, finder)
            },
            {
                StrategySetEnum.AtLeastOneExist, new AtLeastOneExistSet(wordsArray,invertedIndex, finder)
            }
        };
    }

    public IStrategySet Create(StrategySetEnum setName)
    {
        return _strategySets.GetValueOrDefault(setName);
    }
}