using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers.Logic.DocumentsLoader;

public static class WordsListFormatFixer
{
    public static IEnumerable<string> FixWordsList(this List<string> documentWords,
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