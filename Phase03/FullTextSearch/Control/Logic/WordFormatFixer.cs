
namespace FullTextSearch.Control.Logic;
public static class WordFormatFixer
{

    public static string FixWordFormat(this string word)
    {
        return word.ToLower().ToWordRoot();
    }
}