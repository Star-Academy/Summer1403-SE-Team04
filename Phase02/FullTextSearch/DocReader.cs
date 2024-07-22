using System.Runtime.Versioning;

namespace FullTextSearch;

public class DocReader
{
    public static List<List<string>> readDocs()
    {
        return Directory.GetFiles(Resources.databasePath, "*.*", SearchOption.AllDirectories)
            .Select(d => readSingleDoc(d)).ToList();
    }
    private static List<string> readSingleDoc(string path)
    {
        return File.ReadAllText(path)
            .Split(new char[] { ' ', ',', '.', ':', '(', ')', '\n' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}