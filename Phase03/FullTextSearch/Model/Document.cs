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
}