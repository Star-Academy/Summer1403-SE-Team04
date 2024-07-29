using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public static class WordsListFormatFixer
{
    public static IEnumerable<string> FixWordsList(this IEnumerable<string> documentWords,
        List<IStringReformater> reformaters)
    {
        foreach (var word in documentWords)
        {
            var result = word;
            foreach (var format in reformaters) result = format.FixWordFormat(result);

            yield return result;
        }
    }
}