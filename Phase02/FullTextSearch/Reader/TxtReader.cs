namespace FullTextSearch;

public class TxtReader: FileReader
{
    public List<string> ReadSingleFile(string path)
    {
        return ReadSingleFile(path, new char[] { '\n' });
    }
}