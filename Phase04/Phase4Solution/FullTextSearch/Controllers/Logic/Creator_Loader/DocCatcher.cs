using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class DocCatcher : IDocCatcher
{
    public List<Document> DocumentList = new List<Document>();
    public void Write(Document document)
    {
        //todo
        throw new NotImplementedException();
    }

    public List<Document> Load()
    {
        return DocumentList;
    }
}