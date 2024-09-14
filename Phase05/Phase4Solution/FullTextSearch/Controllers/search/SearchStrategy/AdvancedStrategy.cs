using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearch.Controllers.search.SearchStrategy;

public class AdvancedStrategy(IAdvancedFinder finder) : ISearchStrategy
{
    public List<string> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        var inputPhrases =
            query.SplitIntoAdvanceFormattedWords(new List<IStringReformater> { new ToLower(), new ToRoot() });

        return GetValidDocuments(inputPhrases);
    }

    private List<string> GetValidDocuments(string[] phrases)
    {
        var factory = new AdvancedStrategySetFactory(phrases, finder);
        var advancedMustExist = factory.Create(StrategySetEnum.AdvancedMustExist).GetValidDocs();
        var advancedMustNotExist = factory.Create(StrategySetEnum.AdvancedMustNotExist).GetValidDocs();
        var advancedAtLeastOneExists = factory.Create(StrategySetEnum.AdvancedAtLeastOneExist).GetValidDocs();

        return CalculateValidDoc(advancedMustExist, advancedMustNotExist, advancedAtLeastOneExists);
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