using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;

namespace FullTextSearch.Controllers.Logic.StringProcessor;

public static class QueryHandler
{
    public static string[] SplitIntoFormattedWords(this string query, List<IStringReformater> reformaters)
    {
        var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .FixWordsList(reformaters);
        var enumerableWords = words as string[] ?? words.ToArray();
        return enumerableWords;
    }
}