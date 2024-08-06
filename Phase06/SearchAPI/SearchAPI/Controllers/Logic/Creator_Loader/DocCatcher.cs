using SearchAPI.Controllers.Abstraction;
using SearchAPI.Model;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class DocCatcher : IDocCatcher
{
    private readonly List<Document> _documentList = new();

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