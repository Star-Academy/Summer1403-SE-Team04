using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class AdvancedDocFinder(AdvancedInvertedIndex index) : IAdvancedFinder
{
    public IEnumerable<string>? Find(string phrase)
    {
        if (string.IsNullOrEmpty(phrase)) throw new NullOrEmptyQueryException();
        var wordsList = phrase.Split(' ');
        var documentsList = DocumentCacher.GetAllDocs();
        var firstWordDocs = index.InvertedIndexMap.GetValueOrDefault(wordsList[0]).ToList();
        foreach (var docWordStorage in firstWordDocs)
        {
            var occurences = ((DocumentWordsStorage)docWordStorage).WordOccurences.ToList();
            foreach (var indx in occurences)
            {
                var selectedDoc = documentsList.FirstOrDefault(d => d.DocName == docWordStorage.DocName);
                //check if selectedDocs.DocWords[indx] to selectedDocs.DocWords[indx + wordsList.count() - 1] 
                // is equal to phrase
                // if it is:
                yield return selectedDoc.DocName;
            }
        }
        var result = index.InvertedIndexMap
        return result == null ? new List<string>() : result;
    }
}