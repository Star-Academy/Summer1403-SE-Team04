namespace FullTextSearch;

public static class EmptyRemover
{
    public static List<string> RemoveEmptyCells(this List<string> list)
    {
        return (from word in list
            where word != string.Empty
            select word).ToList();
    }
}