using FullTextSearch.Controllers.Logic.Abstraction;
using Porter2Stemmer;

namespace FullTextSearch.Controllers.Logic.StringProcessor;

public class ToRoot : IStringReformater
{
    private static readonly EnglishPorter2Stemmer Stemmer = new();
    private static readonly ToRoot _root;
    public static ToRoot Instance = _root ??= new ToRoot();

    public string FixWordFormat(string word)
    {
        return ToWordRoot(word);
    }

    public string ToWordRoot(string word)
    {
        try
        {
            return Stemmer.Stem(word).Value;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}