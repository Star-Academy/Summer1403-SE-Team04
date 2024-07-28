namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface ITxtReader
{
    IEnumerable<string> Read(string path);
}