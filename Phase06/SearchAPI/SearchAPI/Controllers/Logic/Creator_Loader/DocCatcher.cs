using System.Text.Json;
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
            var name = document.DocName;
            var WordsListJson = JsonSerializer.Serialize(document.DocWords);
            context.Add(new DocDataStore(){Name = name,WordsListJson = WordsListJson});
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