using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers.Logic.StringProcessor;

public class ToLower : IStringReformater
{
    public string FixWordFormat(string word)
    {
        if (string.IsNullOrEmpty(word)) return string.Empty;
        return word.ToLower();
    }
}