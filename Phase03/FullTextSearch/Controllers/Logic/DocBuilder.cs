using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic;

public class DocBuilder(ITxtReader txtReader) : IDocBuilder
{
    public Document Build(string docPath)
    {
        return new Document(docPath, txtReader.Read(docPath));
    }
}