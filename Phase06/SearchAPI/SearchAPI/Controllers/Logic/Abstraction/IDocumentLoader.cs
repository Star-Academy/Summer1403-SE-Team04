using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IDocumentLoader
{
    List<Document> LoadDocumentsList(string directoryPath,
        List<IStringReformater> reformaters);
}