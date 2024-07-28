using System.Text.RegularExpressions;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class TxtReader : ITxtReader
{
    private static TxtReader? _fileReaderInstance;
    private readonly string _splitPattern = @"[^a-zA-Z1-9]";

    private TxtReader()
    {
    }

    public static TxtReader TxtReaderInstance => _fileReaderInstance ??= new TxtReader();

    public IEnumerable<string> Read(string path)
    {
        var fileText = File.ReadAllText(path);
        return Regex.Split(fileText, _splitPattern);
    }
}