namespace FullTextSearch.Controllers.Logic.StringProcessor;

public static class QueryHandler
{
    public static string[] SplitIntoFormattedWords(this string query)
    {
        var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.FixWordFormat());
        var enumerableWords = words as string[] ?? words.ToArray();
        return enumerableWords;
    }
}