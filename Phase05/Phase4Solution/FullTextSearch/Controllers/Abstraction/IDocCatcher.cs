using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Abstraction;

public interface IDocCatcher
{
    void Write(Document document);
    List<Document> Load();
}