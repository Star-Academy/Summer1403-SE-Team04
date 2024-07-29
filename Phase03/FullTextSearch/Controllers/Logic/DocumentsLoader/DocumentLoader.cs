using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.DocumentsLoader;

public class DocumentLoader(IDocReader docReader, IDocBuilder builder) : IDocumentLoader
{
    public IEnumerable<Document> LoadDocumentsList( string directoryPath,
        List<IStringReformater> reformaters)
    {
        var documents = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
            .Select(s => builder.Build(s)).ToList();
        return documents.EditWords(reformaters);
    }
}