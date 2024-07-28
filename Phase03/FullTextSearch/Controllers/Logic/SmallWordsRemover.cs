
using FullTextSearch.Controllers.Reader;

namespace FullTextSearch.Controllers.Logic;

public static class SmallWordsRemover
{
    private static readonly IEnumerable<String> SmallWordsList = FileReader.FileReaderInstance.Read(Resources.SmallWordsPath);
    public static IEnumerable<string> RemoveSmallWords(this IEnumerable<string> list)
    {
        return list.Where(word => !SmallWordsList.Contains(word));
    }
}