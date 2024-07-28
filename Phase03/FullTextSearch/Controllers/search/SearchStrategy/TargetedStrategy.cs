using FullTextSearch.Controllers.Logic.StringProcessor;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.SearchStrategy;

public class TargetedStrategy : ISearchStrategy
{
    private static TargetedStrategy? _targetedStrategy;

    private TargetedStrategy()
    {
    }

    public static TargetedStrategy Instance => _targetedStrategy ??= new TargetedStrategy();

    public IEnumerable<string> Search(string query, InvertedIndex index)
    {
        var inputWords = query.SplitIntoFormattedWords();
        return GetValidDocuments(index, inputWords, MustExistSet.Instance, MustNotExistSet.Instance,
            AtLeastOneExistSet.Instance);
    }

    private IEnumerable<string> GetValidDocuments(InvertedIndex index, string[] words,
        params IStrategySet[] strategySets)
    {
            var mustExist = strategySets.FindByName(StrategySetEnum.MustExist).GetValidDocs(words, index);
            var mustNotExist = strategySets.FindByName(StrategySetEnum.MustNotExist).GetValidDocs(words, index);
            var atLeastOneExists = strategySets.FindByName(StrategySetEnum.AtLeastOneExist).GetValidDocs(words, index);
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