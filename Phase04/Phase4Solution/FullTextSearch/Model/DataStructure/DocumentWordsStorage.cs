
using FullTextSearch.Model.AbstractClass;

namespace FullTextSearch.Model.DataStructure;

public class DocumentWordsStorage : WordInformation
{
    public IEnumerable<int> WordOccurences { get; init; }

    public DocumentWordsStorage(string docName, IEnumerable<int> wordOccurences) : base(docName)
    {
        WordOccurences = wordOccurences;
    }
}