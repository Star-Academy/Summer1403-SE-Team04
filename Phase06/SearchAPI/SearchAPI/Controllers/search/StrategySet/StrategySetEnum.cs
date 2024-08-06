namespace SearchAPI.Controllers.search.StrategySet;

public enum StrategySetEnum
{
    MustExist,
    MustNotExist,
    AtLeastOneExist,
    AdvancedMustExist,
    AdvancedMustNotExist,
    AdvancedAtLeastOneExist
}