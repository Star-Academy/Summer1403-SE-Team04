using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic;

public class DocBuilder(ITxtReader txtReader) : IDocBuilder
{
    public Document Build(string? docPath)
    {
        if (string.IsNullOrEmpty(docPath)) return null;
        return new Document(docPath, txtReader.Read(docPath));
    }
}