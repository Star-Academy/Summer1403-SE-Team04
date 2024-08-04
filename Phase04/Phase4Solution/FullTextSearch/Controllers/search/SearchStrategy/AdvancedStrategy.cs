using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.SearchStrategy;

public class AdvancedStrategy(IAdvancedFinder finder) : ISearchStrategy
{
    
    public IEnumerable<string> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        var inputPhrases =
            query.SplitIntoAdvanceFormattedWords(new List<IStringReformater> { new ToLower(), new ToRoot() });
        
        return GetValidDocuments(inputPhrases);
    }

    private IEnumerable<string> GetValidDocuments(string[] phrases)
    {
        var factory = new AdvancedStrategySetFactory(phrases, finder);
        var advancedMustExist = factory.Create(StrategySetEnum.AdvancedMustExist).GetValidDocs();
        var advancedMustNotExist = factory.Create(StrategySetEnum.AdvancedMustNotExist).GetValidDocs();
        var advancedAtLeastOneExists = factory.Create(StrategySetEnum.AdvancedAtLeastOneExist).GetValidDocs();

        return CalculateValidDoc( advancedMustExist, advancedMustNotExist, advancedAtLeastOneExists);
    }

    private IEnumerable<string> CalculateValidDoc( IEnumerable<string> mustExist, IEnumerable<string> mustNotExist,
        IEnumerable<string> atLeastOneExists)
    {
        if (!mustExist.Any())
            return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any())
            return mustExist.Except(mustNotExist).ToList();
        return mustExist.Intersect(atLeastOneExists).Except(mustNotExist);
    }
}