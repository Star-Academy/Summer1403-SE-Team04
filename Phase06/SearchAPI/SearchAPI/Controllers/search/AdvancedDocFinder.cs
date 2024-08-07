using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.StrategySet;
using SearchAPI.Model;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.search;

public class AdvancedDocFinder([FromServices] IDocCatcher documentCacher,[FromServices] IGarbageRemover remover)
    : IAdvancedFinder
{
    public List<string>? Find(AdvancedInvertedIndex index, string phrase)
    {
        ValidatePhrase(phrase);

        var queryWordsList = PrepareQueryWords(phrase);
        var documentsList = LoadDocuments();
        var firstWordValidDocs = GetFirstWordValidDocuments(index, queryWordsList);

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

    private List<DocumentWordStorage>? GetFirstWordValidDocuments(AdvancedInvertedIndex index, List<string> queryWordsList)
    {
        return index.InvertedIndexMap.GetValueOrDefault(queryWordsList.FirstOrDefault());
    }

    private List<string> FindMatchingDocuments(List<DocumentWordStorage> firstWordValidDocs,
        List<Document> documentsList, List<string> queryWordsList, string phrase)
    {
        var result = new List<string>();

        foreach (var docWordStorage in firstWordValidDocs)
        {
            var occurrences = docWordStorage.WordOccurences;
            var selectedDoc = documentsList.SingleOrDefault(d => d.DocName == docWordStorage.DocName);

            if (selectedDoc != null) AddMatchingDocuments(result, selectedDoc, occurrences, queryWordsList, phrase);
        }

        return result;
    }

    private void AddMatchingDocuments(List<string> result, Document selectedDoc, IEnumerable<int> occurrences,
        List<string> queryWordsList, string phrase)
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