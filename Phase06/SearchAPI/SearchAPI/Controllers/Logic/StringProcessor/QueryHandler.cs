using System.Text.RegularExpressions;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.DocumentsLoader;

namespace SearchAPI.Controllers.Logic.StringProcessor;

public static class QueryHandler
{
    public static string[] SplitIntoFormattedWords(this string query, List<IStringReformater> reformaters)
    {
        if (string.IsNullOrEmpty(query)) return new string[0];
        var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()
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
            if (match.Groups[2].Success)
            {
                if (match.Groups[2].Value is "+" or "-") continue;
                var index = query.IndexOf(match.Value);
                if (index > 0 && (query[index - 1] == '+' || query[index - 1] == '-'))
                {
                    var resultWord = query[index - 1] + match.Groups[2].Value;
                    foreach (var stringReformater in reformaters)
                        resultWord = stringReformater.FixWordFormat(resultWord);
                    result.Add(resultWord);
                }
                else
                {
                    var resultWord = match.Groups[2].Value;
                    foreach (var stringReformater in reformaters)
                        resultWord = stringReformater.FixWordFormat(resultWord);
                    result.Add(match.Groups[2].Value);
                }
            }
            else
            {
                if (match.Value is "+" or "-") continue;

                var resultWord = match.Value;
                foreach (var stringReformater in reformaters) resultWord = stringReformater.FixWordFormat(resultWord);
                result.Add(match.Value);
            }

        return result.ToArray();
    }
}