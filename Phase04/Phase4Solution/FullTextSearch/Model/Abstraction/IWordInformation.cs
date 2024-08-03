namespace FullTextSearch.Model.Abstraction;

public interface IWordInformation
{
    string GetDocumentName();
    IEnumerable<int> GetWordOccurences();
    void AddWordOccurences(int index);

}