using FullTextSearch.Reader;
using Porter2Stemmer;

namespace FullTextSearch.Logic;
public static class WordFormatFixer
{
    private static readonly EnglishPorter2Stemmer Stemmer = new EnglishPorter2Stemmer();
    private static readonly List<String> SmallWordsList = FileReader.FileReaderInstance.ReadSingleFile(Resources.smallWordsPath);

    public static string FixWordFormat(this string word)
    {
        return word.ToLower().ToWordRoot().CheckSmallWords();
    }

    private static string ToWordRoot(this string word)
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

    private static string CheckSmallWords(this string word)
    {
        return SmallWordsList.Contains(word) ? string.Empty : word;
    }
}