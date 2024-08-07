using System.Text.Json;

namespace SearchAPI.Model.Database;

public class DocDataStore
{
    public string name { get; set; }
    public string WordsListJson { get; set; }

    public DocDataStore(Document document)
    {
        name = document.DocName;
        WordsListJson = JsonSerializer.Serialize(document.DocWords);
    }
}