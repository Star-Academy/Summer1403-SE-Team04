using SearchAPI.Model;

namespace SearchAPI.Controllers.Abstraction;

public interface IDocCatcher
{
    void Write(Document document);
    List<Document> Load();
}