using FullTextSearch.Model;

namespace FullTextSearch.Control.Logic.Abstraction;

public interface IDocumentLoader
{
    IEnumerable<Document> LoadDocumentsList(string directoryPath);
}