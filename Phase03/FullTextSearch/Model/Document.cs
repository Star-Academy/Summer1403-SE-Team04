using System.Collections;

namespace FullTextSearch.Model;

public class Document : IEnumerable<string>
{
    public string DocName { get; init; }
    public List<string> DocWords { get; init; }

    public Document(string docName, List<string> docWords)
    {
        DocName = docName;
        DocWords = docWords;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return DocWords.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}