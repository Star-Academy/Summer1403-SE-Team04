using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface IDocReader
{
    public IEnumerable<Document> ReadFromDoc(string directoryPath);

}