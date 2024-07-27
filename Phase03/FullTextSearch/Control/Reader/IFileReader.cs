using System.Collections;

namespace FullTextSearch.Reader;

public interface IFileReader
{
    IEnumerable<string> Read(string path);
}