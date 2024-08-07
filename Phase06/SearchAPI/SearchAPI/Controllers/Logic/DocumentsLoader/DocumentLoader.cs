using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Model;

namespace SearchAPI.Controllers.Logic.DocumentsLoader;

public class DocumentLoader([FromServices]IDocBuilder builder, [FromServices]IGarbageRemover remover ) : IDocumentLoader
{
    public List<Document> LoadDocumentsList(string directoryPath,List<IStringReformater> reformaters)
    {
        var documents = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
            .Select(s => builder.Build(s)).ToList();
        return documents.EditWords(reformaters, remover);
    }
}