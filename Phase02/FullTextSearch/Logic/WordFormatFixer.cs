using Porter2Stemmer;

namespace FullTextSearch;
public static class WordFormatFixer
{
    private readonly static EnglishPorter2Stemmer _stemmer = new EnglishPorter2Stemmer();
    private readonly static List<String> _smallWordsList = new FileReader().ReadSingleFile(Resources.smallWordsPath);

    public static string FixWordFormat(this string word)
    {
        return word.ToLower().ToWordRoot().CheckSmallWords();
    }

    private static string ToWordRoot(this string word)
    {
        try
        {
            return _stemmer.Stem(word).Value ;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static string CheckSmallWords(this string word)
    {
        return _smallWordsList.Contains(word) ? string.Empty : word;
    }
}