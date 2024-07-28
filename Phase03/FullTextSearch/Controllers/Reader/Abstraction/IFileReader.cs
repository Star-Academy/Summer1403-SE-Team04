using System.Collections;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface IFileReader
{
    IEnumerable<string> Read(string path);
}