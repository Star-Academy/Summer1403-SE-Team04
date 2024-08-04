
using FullTextSearch.Model.AbstractClass;

namespace FullTextSearch.Model.DataStructure;

public class DocumentDocsStorage : DocInformation
{
    public IEnumerable<int> WordOccurences { get; init; }

    public DocumentDocsStorage(string docName, IEnumerable<int> wordOccurences) : base(docName)
    {
        WordOccurences = wordOccurences;
    }
}