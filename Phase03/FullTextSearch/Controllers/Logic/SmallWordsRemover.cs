using FullTextSearch.Control.Reader;

namespace FullTextSearch.Control.Logic;

public static class SmallWordsRemover
{
    private static readonly IEnumerable<String> SmallWordsList = FileReader.FileReaderInstance.Read(Resources.smallWordsPath);
    public static IEnumerable<string> RemoveSmallWords(this IEnumerable<string> list)
    {
        return list.Where(word => !SmallWordsList.Contains(word));
    }
}