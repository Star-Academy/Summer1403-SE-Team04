using System.Text.RegularExpressions;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;

namespace FullTextSearch.Controllers.Logic.StringProcessor;

public static class QueryHandler
{
    public static string[] SplitIntoFormattedWords(this string query, List<IStringReformater> reformaters)
    {
        if (string.IsNullOrEmpty(query)) return new String[0];
        var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .FixWordsList(reformaters);
        var enumerableWords = words as string[] ?? words.ToArray();
        return enumerableWords;
    }

    public static string[] SplitIntoAdvanceFormattedWords(this string query, List<IStringReformater> reformaters)
    {
        if (string.IsNullOrEmpty(query)) return [];

        var result = new List<string>();
        
        var matches = Regex.Matches(query, @"([+-]?[^\s""']+)|""([^""]*)""");

        foreach (Match match in matches)
        {
            if (match.Groups[2].Success)
            {
                if(match.Groups[2].Value is "+" or "-")continue;
                int index = query.IndexOf(match.Value);
                if (index > 0 && (query[index - 1] == '+' || query[index - 1] == '-'))
                {
                    result.Add(query[index - 1] + match.Groups[2].Value);
                }
                else
                {
                    result.Add(match.Groups[2].Value);
                }
            }
            else
            {
                if(match.Value is "+" or "-")continue;
                result.Add(match.Value);
            }
        }
        return result.ToArray();
    }
}