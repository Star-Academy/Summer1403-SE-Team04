namespace FullTextSearch.Control.Logic.DocumentsLoader;

public static class WordsListFormatFixer
{
    public static List<string> FixWordsList(this List<string> documentWords)
    {
        return documentWords.Select(w => w.FixWordFormat())
            .RemoveSmallWords().ToList();
    }
}