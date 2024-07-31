using System.Collections;

namespace FullTextSearch.Model;

public class Document(string docName, IEnumerable<string> docWords) : IEnumerable<string>
{
    public string DocName { get; init; } = docName;
    public IEnumerable<string> DocWords { get; init; } = docWords;

    public IEnumerator<string> GetEnumerator()
    {
        return DocWords.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override bool Equals(object? obj)
    {
        try
        {
            if (typeof(object).IsSubclassOf(typeof(Document)))
            {
                var testDoc = ((Document)obj);
                if (docName == testDoc.DocName)
                {
                    var w1 = DocWords.ToList();
                    var w2 = testDoc.DocWords.ToList();
                    for (int i = 0; i < docWords.Count(); i++)
                    {
                        if (w1[i] != w2[i]) return false;
                    }
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