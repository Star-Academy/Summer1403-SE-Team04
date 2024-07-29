using FullTextSearch.Controllers.Logic.Abstraction;
using Porter2Stemmer;

namespace FullTextSearch.Controllers.Logic.StringProcessor;

public class ToRoot : IStringReformater
{
    private static readonly EnglishPorter2Stemmer Stemmer = new();
    public string FixWordFormat(string word)
    {
        return ToWordRoot(word);
    }

    private string ToWordRoot(string word)
    {
        return Stemmer.Stem(word).Value;
        
    }
}