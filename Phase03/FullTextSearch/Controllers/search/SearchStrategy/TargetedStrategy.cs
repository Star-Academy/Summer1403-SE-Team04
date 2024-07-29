using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.SearchStrategy;

public class TargetedStrategy(InvertedIndex index, IStrategySetFactory factory) : ISearchStrategy
{
    public IEnumerable<string> Search(string query)
    {
        var inputWords =
            query.SplitIntoFormattedWords(new List<IStringReformater> { new ToLower(), new ToRoot() });
        return GetValidDocuments(inputWords, index);
    }

    private IEnumerable<string> GetValidDocuments(string[] words, InvertedIndex index)
    {
        factory.SetStrategySets(words, index);
        var mustExist = factory.Create(StrategySetEnum.MustExist).GetValidDocs();
        var mustNotExist = factory.Create(StrategySetEnum.MustNotExist).GetValidDocs();
        var atLeastOneExists = factory.Create(StrategySetEnum.AtLeastOneExist).GetValidDocs();
        return CalculateValidDoc(mustExist, mustNotExist, atLeastOneExists);
    }

    private IEnumerable<string> CalculateValidDoc(IEnumerable<string> mustExist, IEnumerable<string> mustNotExist,
        IEnumerable<string> atLeastOneExists)
    {
        if (!mustExist.Any())
            return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any())
            return mustExist.Except(mustNotExist).ToList();
        return mustExist.Intersect(atLeastOneExists).Except(mustNotExist);
    }
}