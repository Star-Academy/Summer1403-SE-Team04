using SearchAPI.Model;

namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IDocumentLoader
{
    List<Document> LoadDocumentsList(string directoryPath,
        List<IStringReformater> reformaters);
}