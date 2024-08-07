using SearchAPI.Controllers.Abstraction;
using SearchAPI.Model;
using SearchAPI.Model.Database;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class DocCatcher(FullTextSearchDbContext context) : IDocCatcher
{
    public void Write(Document document)
    {
        try
        {
            context.Add(new DocDataStore(document));
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine("add Fail");
        }
    }

    public List<Document> Load()
    {
        return context.DocDataStores.Select(d => new Document(d)).ToList();
    }
}