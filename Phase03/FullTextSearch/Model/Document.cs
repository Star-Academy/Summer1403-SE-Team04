namespace FullTextSearch.Model;

public class Document
{
    public string DocName { get; init; }
    public List<string> DocWords { get; init; }

    public Document(string docName, List<string> docWords)
    {
        DocName = docName;
        DocWords = docWords;
    }
}