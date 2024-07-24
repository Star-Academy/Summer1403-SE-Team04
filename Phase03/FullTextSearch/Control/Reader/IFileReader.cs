namespace FullTextSearch.Reader;

public interface IFileReader
{
    List<string> Read(string path);
}