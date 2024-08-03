using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.SearchStrategy;

public class AdvancedStrategy(IFinder finder) : ISearchStrategy
{
    
    public IEnumerable<string> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new NullOrEmptyQueryException();
        var inputPhrases =
            query.SplitIntoFormattedWords(new List<IStringReformater> { new ToLower(), new ToRoot() });
        // todo : split by ""
        return GetValidDocuments(inputPhrases);
    }

    private IEnumerable<string> GetValidDocuments(string[] phrases)
    {
        var factory = new AdvancedStrategySetFactory(phrases, finder);
        
        var mustExist = factory.Create(StrategySetEnum.MustExist).GetValidDocs();
        var mustNotExist = factory.Create(StrategySetEnum.MustNotExist).GetValidDocs();
        var atLeastOneExists = factory.Create(StrategySetEnum.AtLeastOneExist).GetValidDocs();
        var advancedMustExist = factory.Create(StrategySetEnum.AdvancedMustExist).GetValidDocs();
        var advancedMustNotExist = factory.Create(StrategySetEnum.AdvancedMustNotExist).GetValidDocs();
        var advancedAtLeastOneExists = factory.Create(StrategySetEnum.AdvancedAtLeastOneExist).GetValidDocs();

        return CalculateValidDoc(mustExist, mustNotExist, atLeastOneExists, advancedMustExist, advancedMustNotExist, advancedAtLeastOneExists);
    }

    private IEnumerable<string> CalculateValidDoc(IEnumerable<string> mustExist, IEnumerable<string> mustNotExist,
        IEnumerable<string> atLeastOneExists, IEnumerable<string> advancedMustExist, IEnumerable<string> advancedMustNotExist,
        IEnumerable<string> advancedAtLeastOneExists)
    {
        mustExist = mustExist.Union(advancedMustExist);
        mustNotExist = mustNotExist.Union(advancedMustNotExist);
        atLeastOneExists = atLeastOneExists.Union(advancedAtLeastOneExists);
        
        if (!mustExist.Any())
            return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any())
            return mustExist.Except(mustNotExist).ToList();
        return mustExist.Intersect(atLeastOneExists).Except(mustNotExist);
    }
}