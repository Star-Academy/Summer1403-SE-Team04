using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader;

namespace FullTextSearch.Controllers.Logic;

public class SmallWordsRemover : IGarbageRemover
{
    private static readonly HashSet<string> SmallWordsList =
        new TxtReader().Read(Resources.SmallWordsPath).ToHashSet();

    public List<string> Remove(List<string> wordsList)
    {
        if (wordsList == null) return new List<string>(Array.Empty<string>());
        return wordsList.Where(word => !SmallWordsList.Contains(word)).ToList();
    }
}