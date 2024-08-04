namespace FullTextSearch.Model.DataStructure;

public class DocumentWordStorage
{
    public List<int> WordOccurences { get; set; }
    public string DocName { get; init; }

    public DocumentWordStorage(string docName, List<int> wordOccurences)
    {
        WordOccurences = wordOccurences;
        DocName = docName;
    }

    public void addd(int a)
    {
        WordOccurences.Add(a);
    }
}