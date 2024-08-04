using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class AdvancedDocFinder(AdvancedInvertedIndex index, IDocCatcher documentCacher , IGarbageRemover remover) : IAdvancedFinder
{
    public List<string>? Find(string phrase)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(phrase)) throw new NullOrEmptyQueryException();
        var queryWordsList = remover.Remove(phrase.Split(' ').ToList());
        var documentsList = documentCacher.Load();
        var firstWordValidDocs = index.InvertedIndexMap.GetValueOrDefault(queryWordsList.ToList()[0]);
        if (firstWordValidDocs == null) return result;
        foreach (var docWordStorage in firstWordValidDocs.ToList())
        {
            var occurences = ((DocumentWordStorage)docWordStorage).WordOccurences.ToList();
            var selectedDoc = documentsList.FirstOrDefault(d => d.DocName == docWordStorage.DocName);

            foreach (var placement in occurences)
            {
                var resultPhrase = string.Join(" ", selectedDoc.DocWords.ToList()
                    .GetRange(placement, queryWordsList.Count()));
                if(resultPhrase.Equals(phrase))
                    result.Add(selectedDoc.DocName);
            }
        }

        return result;
    }
}
