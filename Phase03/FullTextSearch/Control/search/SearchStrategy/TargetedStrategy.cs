using FullTextSearch.Control.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Control.search.SearchStrategy;

public class TargetedStrategy : ISearchStrategy
{
    private static TargetedStrategy _targetedStrategy;

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
            var mustExist = strategySets.FindByName("MustExist").GetValidDocs(words, index);
            var mustNotExist = strategySets.FindByName("MustNotExist").GetValidDocs(words, index);
            var atLeastOneExists = strategySets.FindByName("AtLeastOneExists").GetValidDocs(words, index);
            return CalculateValidDoc(mustExist, mustNotExist, atLeastOneExists);

    }

    private IEnumerable<string> CalculateValidDoc(IEnumerable<string> mustExist, IEnumerable<string> mustNotExist,
        IEnumerable<string> atLeastOneExists)
    {
        if (!mustExist.Any())
            return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any())
            return mustExist.Except(mustNotExist).ToList();
        return mustExist.Except(mustNotExist).Except(mustExist.Except(atLeastOneExists)).ToList();
    }
}