using FullTextSearch.DataStructure;

namespace FullTextSearch.Logic;

public class WordSearcher
{
    private readonly InvertedIndex _index;
    

    public WordSearcher(InvertedIndex invertedIndex)
    {
        _index = invertedIndex;
    }

    public List<string> FindDocuments(string query)
    {
        var inputWords = QueryHandler(query);
        var mustExist = GetMustExistWordsList(inputWords);
        var mustNotExist = GetMustNotExistWordsList(inputWords);
        var atLeastOneExists = GetAtLeastOneExistsWordsList(inputWords);
        return GetValidDocuments(mustExist, mustNotExist, atLeastOneExists);
    }

    private List<string> GetValidDocuments(List<string> mustExist, List<string> mustNotExist,List<string>  atLeastOneExists)
    {
        if (!mustExist.Any())
            return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any())
            return mustExist.Except(mustNotExist).ToList();
        return mustExist.Except(mustNotExist).Except(mustExist.Except(atLeastOneExists)).ToList();
    }
    private string[] QueryHandler(string query)
    {
        var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.FixWordFormat());
        var enumerableWords = words as string[] ?? words.ToArray();
        return enumerableWords;
    }

    private List<string> GetMustExistWordsList(string[] wordsArray)
    {
        return wordsArray.Where(word => !word.StartsWith('+') && !word.StartsWith('-'))
            .Select(FindWordInDocuments)
            .ToList()
            .Intersect();
    }
    private List<string> GetMustNotExistWordsList(string[] wordsArray)
    {
        return wordsArray.Where(word => word.StartsWith('-'))
            .Select(word => FindWordInDocuments(word.Substring(1)))
            .ToList()
            .Union();

    }
    private List<string> GetAtLeastOneExistsWordsList(string[] wordsArray)
    {
        return wordsArray.Where(word => word.StartsWith('+'))
            .Select(word => FindWordInDocuments(word.Substring(1)))
            .ToList()
            .Union();
    }
    
    private List<string> FindWordInDocuments(string word)
    {
        try
        {
            var result = _index.InvertedIndexMap.GetValueOrDefault(word);
            return result == null ? new List<string>() : result;
        }
        catch (NullReferenceException r)
        {
            Console.WriteLine(r);
            throw;
        }
    }
}