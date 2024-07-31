using System.Text.RegularExpressions;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class TxtReader : ITxtReader
{
    private const string SplitPattern = @"[^a-zA-Z1-9]";

    public IReadOnlyList<string> Read(string? path)
    {
        if (path==null||path==string.Empty)
        {
            return new List<string>();
        }
        var fileText = File.ReadAllText(path);
        return Regex.Split(fileText, SplitPattern);
    }
}