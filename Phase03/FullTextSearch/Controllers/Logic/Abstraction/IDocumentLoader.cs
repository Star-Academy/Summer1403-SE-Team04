using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IDocumentLoader
{
    IEnumerable<Document> LoadDocumentsList(string directoryPath,
        List<IStringReformater> reformaters);
}