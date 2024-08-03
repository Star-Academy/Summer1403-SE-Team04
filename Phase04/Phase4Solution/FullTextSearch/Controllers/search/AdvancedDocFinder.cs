using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class AdvancedDocFinder(AdvancedInvertedIndex index, DocCatcher documentCacher) : IAdvancedFinder
{
    public IEnumerable<string>? Find(string phrase)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(phrase)) throw new NullOrEmptyQueryException();
        var wordsList = phrase.Split(' ');
        var documentsList = documentCacher.Load();
        var firstWordDocs = index.InvertedIndexMap.GetValueOrDefault(wordsList[0]).ToList();
        foreach (var docWordStorage in firstWordDocs)
        {
            var occurences = ((DocumentWordsStorage)docWordStorage).WordOccurences.ToList();
            foreach (var indx in occurences)
            {
                var selectedDoc = documentsList.FirstOrDefault(d => d.DocName == docWordStorage.DocName);
                var resultPhrase = String.Join(" ", selectedDoc.DocWords.ToList().GetRange(indx, wordsList.Count()));
                if(resultPhrase == phrase)
                    result.Add(selectedDoc.DocName);
            }
        }

        return result;
    }
}