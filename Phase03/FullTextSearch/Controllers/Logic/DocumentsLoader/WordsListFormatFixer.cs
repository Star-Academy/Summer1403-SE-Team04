
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public static class WordsListFormatFixer
{
    public static IEnumerable<string> FixWordsList(this IEnumerable<string> documentWords)
    {
        return documentWords.Select(w => w.FixWordFormat()).ToList();
    }
}