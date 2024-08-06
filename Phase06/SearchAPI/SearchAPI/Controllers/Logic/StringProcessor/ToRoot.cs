using SearchAPI.Controllers.Logic.Abstraction;
using Porter2StemmerStandard;

namespace SearchAPI.Controllers.Logic.StringProcessor;

public class ToRoot : IStringReformater
{
    private static readonly EnglishPorter2Stemmer Stemmer = new();

    public string FixWordFormat(string word)
    {
        return ToWordRoot(word);
    }

    private string ToWordRoot(string phrase)
    {
        if (string.IsNullOrEmpty(phrase)) return string.Empty;
        var splittedWords = phrase.Split(' ');
        return string.Join(' ', splittedWords.Select(w => Stemmer.Stem(w).Value));
    }
}