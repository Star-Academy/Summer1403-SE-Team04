using System.Text.RegularExpressions;
using SearchAPI.Controllers.Reader.Abstraction;

namespace SearchAPI.Controllers.Reader;

public class TxtReader : ITxtReader
{
    private const string SplitPattern = @"[^a-zA-Z1-9]";

    public IReadOnlyList<string> Read(string? path)
    {
        if (string.IsNullOrEmpty(path)) return new List<string>();

        var fileText = File.ReadAllText(path);
        return Regex.Split(fileText, SplitPattern);
    }
}