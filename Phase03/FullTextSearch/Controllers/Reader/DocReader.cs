using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class DocReader( IGarbageRemover remover, ITxtReader txtReader) : IDocReader
{

    public IEnumerable<string> Read(string path)
    {
        return remover.Remove(txtReader.Read(path));
    }
}