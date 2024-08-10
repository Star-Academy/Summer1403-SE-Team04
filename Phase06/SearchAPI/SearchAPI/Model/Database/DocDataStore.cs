using System.Text.Json;

namespace SearchAPI.Model.Database;

public class DocDataStore
{
    public string Name { get; set; }
    public string WordsListJson { get; set; }
    //
    // public DocDataStore(string name, string wordsListJson)
    // {
    //     Name = name;
    //     WordsListJson = wordsListJson;
    // }
}