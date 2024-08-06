using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Reader.Abstraction;
using SearchAPI.Model;

namespace SearchAPI.Controllers.Logic;

public class DocBuilder(ITxtReader txtReader, IDocCatcher docCatcher) : IDocBuilder
{
    public Document Build(string? docPath)
    {
        if (string.IsNullOrEmpty(docPath)) return null;
        var doc = new Document(docPath, txtReader.Read(docPath).ToList());
        docCatcher.Write(doc);
        return doc;
    }
}