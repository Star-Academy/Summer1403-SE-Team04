namespace SearchAPI.Model;

public class Document(string docName, List<string> docWords) : List<string>
{
    public string DocName { get; init; } = docName;
    public List<string> DocWords { get; init; } = docWords;

    public IEnumerator<string> GetEnumerator()
    {
        return DocWords.GetEnumerator();
    }

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