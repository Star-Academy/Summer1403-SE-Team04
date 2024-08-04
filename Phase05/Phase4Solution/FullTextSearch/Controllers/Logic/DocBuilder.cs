using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic;

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