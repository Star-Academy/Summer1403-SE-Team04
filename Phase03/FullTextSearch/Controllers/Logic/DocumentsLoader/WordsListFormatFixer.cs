using System.Collections;
using FullTextSearch.Control.Logic.StringProcessor;

namespace FullTextSearch.Control.Logic.DocumentsLoader;

public static class WordsListFormatFixer
{
    public static IEnumerable<string> FixWordsList(this IEnumerable<string> documentWords)
    {
        return documentWords.Select(w => w.FixWordFormat())
            .RemoveSmallWords().ToList();
    }
}