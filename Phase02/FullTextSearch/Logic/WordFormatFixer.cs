using Porter2Stemmer;

namespace FullTextSearch;
public static class WordFormatFixer
{
    private static EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();
    private static List<String> SmallWordsList = new FileReader().ReadSingleFile(Resources.smallWordsPath);

    public static string FixWordFormat(this string word)
    {
        return word.ToLower().ToWordRoot().CheckSmallWords();
    }

    private static string ToWordRoot(this string word)
    {
        try
        {
            return stemmer.Stem(word).Value ;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static string CheckSmallWords(this string word)
    {
        return SmallWordsList.Contains(word) ? string.Empty : word;
    }
}