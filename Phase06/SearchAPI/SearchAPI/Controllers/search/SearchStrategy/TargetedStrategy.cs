using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet;

namespace SearchAPI.Controllers.search.SearchStrategy;

public class TargetedStrategy(IFinder finder) : ISearchStrategy
{
    public List<string> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        var inputWords =
            query.SplitIntoFormattedWords(new List<IStringReformater> { new ToLower(), new ToRoot() });
        return GetValidDocuments(inputWords);
    }

    private List<string> GetValidDocuments(string[] words)
    {
        var factory = new StrategySetFactory(words, finder);
        var mustExist = factory.Create(StrategySetEnum.MustExist).GetValidDocs();
        var mustNotExist = factory.Create(StrategySetEnum.MustNotExist).GetValidDocs();
        var atLeastOneExists = factory.Create(StrategySetEnum.AtLeastOneExist).GetValidDocs();
        return CalculateValidDoc(mustExist, mustNotExist, atLeastOneExists);
    }

    private List<string> CalculateValidDoc(List<string> mustExist, List<string> mustNotExist,
        List<string> atLeastOneExists)
    {
        if (!mustExist.Any())
            return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any())
            return mustExist.Except(mustNotExist).ToList();
        return mustExist.Intersect(atLeastOneExists).Except(mustNotExist).ToList();
    }
}