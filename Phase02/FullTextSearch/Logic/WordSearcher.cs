namespace FullTextSearch;

public class WordSearcher
{
    public InvertedIndex Index;

    public WordSearcher(InvertedIndex invertedIndex)
    {
        Index = invertedIndex;
    }

    public List<string> FindDocuments(string query)
    {
        var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(w => w.FixWordFormat());

        var mustExist = words.Where(word => !word.StartsWith('+') && !word.StartsWith('-'))
            .Select(FindWordInDocuments)
            .ToList()
            .Intersect();

        var mustNotExist = words.Where(word => word.StartsWith('-'))
            .Select(word => FindWordInDocuments(word.Substring(1)))
            .ToList()
            .Union();

        var atLeastOneExists = words.Where(word => word.StartsWith('+'))
            .Select(word => FindWordInDocuments(word.Substring(1)))
            .ToList()
            .Union();


        if (!mustExist.Any()) return atLeastOneExists.Except(mustNotExist).ToList();
        if (!atLeastOneExists.Any()) return mustExist.Except(mustNotExist).ToList();
        return mustExist.Except(mustNotExist).Except(mustExist.Except(atLeastOneExists)).ToList();
    }

    private List<string> FindWordInDocuments(string word)
    {
        try
        {
            var result = Index.InvertedIndexMap.GetValueOrDefault(word);
            return result == null ? new List<string>() : result;
        }
        catch (NullReferenceException r)
        {
            Console.WriteLine(r);
            throw;
        }
    }
}