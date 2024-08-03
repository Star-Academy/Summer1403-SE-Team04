using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class DocCatcher : IDocCatcher
{
    private List<Document> _documentList = new List<Document>();
    public void Write(Document document)
    {
        if (document==null)return;
        _documentList.Add(document);
    }

    public List<Document> Load()
    {
        return _documentList;
    }
}