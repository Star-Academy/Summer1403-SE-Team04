namespace FullTextSearch.Logic;

public static class EmptyRemover
{
    public static List<string> RemoveEmptyCells(this List<string> list)
    {
        return list.Where(word => word != string.Empty).ToList();
    }
}