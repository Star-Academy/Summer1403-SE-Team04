namespace FullTextSearch;

public class Document
{
    public string DocName { get; set; }
    public List<string> DocWords { get; set; }

    public Document(string docName, List<string> docWords)
    {
        DocName = docName;
        DocWords = docWords;
    }
}