using FullTextSearch.Model;

namespace FullTextSearch.Reader;

public class DocReader : FileReader
{
    private static DocReader _docReaderInstance;
    public static DocReader DocReaderInstance => _docReaderInstance ??= new DocReader();
    private DocReader(){}

    public List<Document> ReadDocs()
    {
            
        try
        {
            return Directory.GetFiles(Resources.documentsPath, "*.*", SearchOption.AllDirectories)
                .Select(s => new Document(s, ReadSingleFile(s)))
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
}