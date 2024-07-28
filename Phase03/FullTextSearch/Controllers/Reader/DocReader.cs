using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class DocReader : IDocReader
{
    private static DocReader? _docReaderInstance;
    public static DocReader DocReaderInstance => _docReaderInstance ??= new DocReader();
    private DocReader(){}
    
    public IEnumerable<string> Read(string path,IGarbageRemover remover)
    {
        return remover.Remove(TxtReader.TxtReaderInstance.Read(path));
    }
}