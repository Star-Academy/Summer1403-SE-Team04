
namespace FullTextSearch.Model.DataStructure;

public class AdvancedInvertedIndex
{
    public Dictionary<string, List<DocumentWordStorage>> InvertedIndexMap { get; init; }
    public string DirectoryPath { get; init; }

    public AdvancedInvertedIndex(List<Document> documents, string directoryPath)
    {
        InvertedIndexMap = BuildInvertedIndex(documents);
        DirectoryPath = directoryPath;
    }

    public AdvancedInvertedIndex(Dictionary<string, List<DocumentWordStorage>> invertedIndexMap, string directoryPath)
    {
        InvertedIndexMap = invertedIndexMap;
        DirectoryPath = directoryPath;
    }

    private Dictionary<string, List<DocumentWordStorage>> BuildInvertedIndex(List<Document> documents)
    {
        var doxxx = documents
            .SelectMany(doc => doc.DocWords.Select(word => new { word, doc.DocName }))
            .GroupBy(x => x.word)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => new DocumentWordStorage(x.DocName, new List<int>())).ToList());

        foreach (var entry in doxxx)
        {
            var wordInformationList = entry.Value;
            foreach (var documentWordStorage in wordInformationList)
            {
                var selectedDoc = documents.SingleOrDefault(d => d.DocName == documentWordStorage.DocName);
                for (int i = 0; i < selectedDoc.DocWords.Count(); i++)
                {
                    var docWord = selectedDoc.DocWords.ToList()[i];
                    if (docWord == entry.Key)
                    {
                        documentWordStorage.WordOccurences.Add(i);
                        // var selectedValue = entry.Value;
                        // selectedValue.ToList()[s].addd(i);
                        // entry.Value.
                        // doxxx.TryAdd(entry.Key, selectedValue);
                    }
                }
            }
        }

        return doxxx;
    }
}