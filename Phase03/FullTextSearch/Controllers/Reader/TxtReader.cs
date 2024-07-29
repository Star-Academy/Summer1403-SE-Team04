using System.Text.RegularExpressions;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class TxtReader : ITxtReader
{
    private static TxtReader? _fileReaderInstance;
    private const string SplitPattern = @"[^a-zA-Z1-9]";

    private TxtReader()
    {
    }

    public static TxtReader TxtReaderInstance => _fileReaderInstance ??= new TxtReader();

    public IReadOnlyList<string> Read(string path)
    {
        var fileText = File.ReadAllText(path);
        return Regex.Split(fileText, SplitPattern);
    }
}