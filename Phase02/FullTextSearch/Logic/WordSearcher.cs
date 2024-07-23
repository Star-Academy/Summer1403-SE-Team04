using System.Runtime.CompilerServices;

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
        var words = query.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        var mustExist = (from word in words
            where (!word.StartsWith('+') && !word.StartsWith('-'))
            select FindWordInDocuments(word.FixWordFormat())).ToList().Intersect();
        var mustNotExist =(from word in words
            where (word.StartsWith('-'))
            select FindWordInDocuments(word.Remove(0, 1).FixWordFormat())).ToList().Union();
        var atLeastOneExists = (from word in words
            where (word.StartsWith('+'))
            select FindWordInDocuments(word.Remove(0, 1).FixWordFormat())).ToList().Union();
        if (mustExist.Count == 0) return atLeastOneExists.Except(mustNotExist).ToList();
        else if (atLeastOneExists.Count == 0) return mustExist.Except(mustNotExist).ToList();
        else return mustExist.Except(mustNotExist).Except(mustExist.Except(atLeastOneExists)).ToList();
    }
    
    private List<string> FindWordInDocuments(string word)
    {
        try
        {
            var result = Index.InvertedIndexMap.GetValueOrDefault(word);
            return result==null?new List<string>():result;
        }
        catch (NullReferenceException r)
        {
            Console.WriteLine(r);
            throw;
        }
    }
}