namespace FullTextSearch.Model.DataStructure;

public class DocumentWordStorage
{
    public DocumentWordStorage(string docName, List<int> wordOccurences)
    {
        WordOccurences = wordOccurences;
        DocName = docName;
    }

    public List<int> WordOccurences { get; set; }
    public string DocName { get; init; }

    public void addd(int a)
    {
        WordOccurences.Add(a);
    }
}