using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Logic.StringProcessor;

public class ToLower : IStringReformater
{
    public string FixWordFormat(string word)
    {
        if (string.IsNullOrEmpty(word)) return string.Empty;
        return word.ToLower();
    }
}