using Porter2Stemmer;

namespace FullTextSearch.Control.Logic;

public static class WordRootProcessor
{
    private static readonly EnglishPorter2Stemmer Stemmer = new EnglishPorter2Stemmer();

    public static string ToWordRoot(this string word)
    {
        try
        {
            return Stemmer.Stem(word).Value ;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}