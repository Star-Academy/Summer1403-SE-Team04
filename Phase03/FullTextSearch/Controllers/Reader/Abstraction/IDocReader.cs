using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface IDocReader
{ 
    IEnumerable<string> Read(string path, IGarbageRemover remover);
}