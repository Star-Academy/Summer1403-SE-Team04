namespace FullTextSearch;

public class TxtReader: IFileReader
{
    public static List<string> ReadSingleFile(string path)
    {
        return IFileReader.ReadSingleFile(path, new char[] { '\n' });
    }
}