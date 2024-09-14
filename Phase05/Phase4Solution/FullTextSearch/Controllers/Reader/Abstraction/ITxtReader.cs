namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface ITxtReader
{
    IReadOnlyList<string> Read(string path);
}