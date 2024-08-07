using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class DocCatcher : IDocCatcher
{
    public readonly List<Document> _documentList = new();

    public void Write(Document document)
    {
        if (document == null) return;
        _documentList.Add(document);
    }

    public List<Document> Load()
    {
        return _documentList;
    }
}