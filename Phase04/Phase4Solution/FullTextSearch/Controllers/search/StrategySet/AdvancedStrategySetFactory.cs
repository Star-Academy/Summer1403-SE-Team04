using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet.AdvancedSets;
using FullTextSearch.Controllers.search.StrategySet.BasicSets;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.StrategySet;

public class AdvancedStrategySetFactory
{
    private readonly IReadOnlyDictionary<StrategySetEnum, IStrategySet> _strategySets;

    public AdvancedStrategySetFactory(string[] wordsArray, IFinder finder)
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
            },
            {
                StrategySetEnum.AdvancedMustExist, new AdvancedMustExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.MustNotExist, new AdvancedMustNotExistSet(wordsArray, finder)
            },
            {
                StrategySetEnum.AtLeastOneExist, new AdvancedAtLeastOneExistsSet(wordsArray, finder)
            }
        };
    }

    public IStrategySet Create(StrategySetEnum setName)
    {
        return _strategySets.GetValueOrDefault(setName);
    }
}