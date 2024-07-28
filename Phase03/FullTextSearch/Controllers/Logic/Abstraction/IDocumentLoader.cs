using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IDocumentLoader
{
    IEnumerable<Document> LoadDocumentsList(string directoryPath);
}