using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public static class WordsListFormatFixer 
{
    public static IEnumerable<string> FixWordsList(this IEnumerable<string> documentWords,List<IStringReformater> reformaters)
    {

        return documentWords.Select(w =>
        {
            foreach (var format in reformaters)
            {
                w = format.FixWordFormat(w);
            }

            return w;
        });
    }
}