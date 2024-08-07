using System.Text.Json;
using SearchAPI.Model.Database;

namespace SearchAPI.Model;

public class Document
{
    public string DocName { get; init; }
    public List<string> DocWords { get; init; }

    public Document(string docName, List<string> docWords)
    {
        DocName = docName;
        DocWords = DocWords;
    }

    public Document(DocDataStore docDataStore)
    {
        DocName = docDataStore.name;
        DocWords = JsonSerializer.Deserialize<List<string>>(docDataStore.WordsListJson, WriteOptions);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return DocWords.GetEnumerator();
    }

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public override bool Equals(object? obj)
    {
        try
        {
            if (typeof(object).IsSubclassOf(typeof(Document)))
            {
                var testDoc = (Document)obj;
                if (DocName == testDoc.DocName)
                {
                    var w1 = DocWords.ToList();
                    var w2 = testDoc.DocWords.ToList();
                    for (var i = 0; i < DocWords.Count(); i++)
                        if (w1[i] != w2[i])
                            return false;
                }

                return true;
            }
        }
        catch (Exception e)
        {
        }

        return false;
    }
}