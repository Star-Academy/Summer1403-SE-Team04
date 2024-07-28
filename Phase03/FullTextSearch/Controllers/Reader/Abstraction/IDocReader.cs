using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface IDocReader
{
    public IEnumerable<string> Read(string path, IGarbageRemover remover);
}