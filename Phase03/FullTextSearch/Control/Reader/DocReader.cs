using System.Collections;
using FullTextSearch.Model;
using FullTextSearch.Reader;

namespace FullTextSearch.Control.Reader;

public class DocReader : IFileReader
{
    private static DocReader? _docReaderInstance;
    public static DocReader DocReaderInstance => _docReaderInstance ??= new DocReader();
    private DocReader(){}

    public IEnumerable<Document> ReadDocs(string directoryPath)
    {
        try
        {
            return Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                .Select(s => new Document(s, Read(s)))
                .ToList();
        }
        catch (DirectoryNotFoundException d)
        {
            Console.WriteLine(d);
            throw new FileProcessingException(d.Message);
        }
        catch (FileLoadException e)
        {
            Console.WriteLine(e);
            throw new FileProcessingException(e.Message);
        }
        catch (IOException d)
        {
            Console.WriteLine(d);
            throw new FileProcessingException(d.Message);
        }
    }

    public IEnumerable<string> Read(string path)
    {
        return FileReader.FileReaderInstance.Read(path);
    }
}