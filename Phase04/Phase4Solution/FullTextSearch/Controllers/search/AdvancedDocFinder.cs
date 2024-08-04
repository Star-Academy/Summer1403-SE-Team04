using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search;

public class AdvancedDocFinder(AdvancedInvertedIndex index, IDocCatcher documentCacher , IGarbageRemover remover) : IAdvancedFinder
{
    /*public List<string>? Find(string phrase)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(phrase)) throw new NullOrEmptyQueryException();
        var queryWordsList = remover.Remove(phrase.Split(' ').ToList());
        var documentsList = documentCacher.Load();
        var firstWordValidDocs = index.InvertedIndexMap.GetValueOrDefault(queryWordsList.ToList()[0]);
        if (firstWordValidDocs == null) return result;
        
        
        foreach (var docWordStorage in firstWordValidDocs)
        {
            var occurences = docWordStorage.WordOccurences;
            var selectedDoc = documentsList.SingleOrDefault(d => d.DocName == docWordStorage.DocName);

            foreach (var placement in occurences)
            {
                var resultPhrase = string.Join(" ", selectedDoc.DocWords.ToList()
                    .GetRange(placement, queryWordsList.Count()));
                if(resultPhrase.Equals(phrase))
                    result.Add(selectedDoc.DocName);
            }
        }

        return result;
    }*/
    
    public List<string>? Find(string phrase)
    {
        ValidatePhrase(phrase);

        var queryWordsList = PrepareQueryWords(phrase);
        var documentsList = LoadDocuments();
        var firstWordValidDocs = GetFirstWordValidDocuments(queryWordsList);

        if (firstWordValidDocs == null) return new List<string>();

        return FindMatchingDocuments(firstWordValidDocs, documentsList, queryWordsList, phrase);
    }
    
    private void ValidatePhrase(string phrase)
    {
        if (string.IsNullOrEmpty(phrase))
            throw new NullOrEmptyQueryException();
    }
    
    private List<string> PrepareQueryWords(string phrase)
    {
        return remover.Remove(phrase.Split(' ').ToList());
    }

    private List<Document> LoadDocuments()
    {
        return documentCacher.Load();
    }

    private List<DocumentWordStorage>? GetFirstWordValidDocuments(List<string> queryWordsList)
    {
        return index.InvertedIndexMap.GetValueOrDefault(queryWordsList.FirstOrDefault());
    }
    
    private List<string> FindMatchingDocuments(List<DocumentWordStorage> firstWordValidDocs, List<Document> documentsList, List<string> queryWordsList, string phrase)
    {
        var result = new List<string>();

        foreach (var docWordStorage in firstWordValidDocs)
        {
            var occurrences = docWordStorage.WordOccurences;
            var selectedDoc = documentsList.SingleOrDefault(d => d.DocName == docWordStorage.DocName);

            if (selectedDoc != null)
            {
                AddMatchingDocuments(result, selectedDoc, occurrences, queryWordsList, phrase);
            }
        }

        return result;
    }
    
    private void AddMatchingDocuments(List<string> result, Document selectedDoc, IEnumerable<int> occurrences, List<string> queryWordsList, string phrase)
    {
        foreach (var placement in occurrences)
        {
            var resultPhrase = string.Join(" ", selectedDoc.DocWords.ToList()
                .GetRange(placement, queryWordsList.Count()));
            if (resultPhrase.Equals(phrase))
                result.Add(selectedDoc.DocName);
        }
    }
}
