using Porter2Stemmer;

namespace FullTextSearch;
public static class WordFormatFixer
{
    private static EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();
    private static List<String> SmallWordsList = TxtReader.ReadSingleFile(Resources.smallWordsPath);

    public static string FixWordFormat(this string word)
    {
        return word.ToLower().ToWordRoot().CheckSmallWords();
    }

    private static string ToWordRoot(this string word)
    {
        return stemmer.Stem(word).Value;
    }

    private static string CheckSmallWords(this string word)
    {
        return SmallWordsList.Contains(word) ? string.Empty : word;
    }
}