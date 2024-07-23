namespace FullTextSearch;

public static class MathHelper
{
    public static List<T> Union<T>(this List<List<T>> list)
    {
        try
        {
            if (list.Count == 0) return new List<T>();
            var initialList = new List<T>();
            foreach (var item in list) initialList = initialList.Union(item).ToList();

            return initialList;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<T> Intersect<T>(this List<List<T>> list)
    {
        try
        {
            if (list.Count == 0) return new List<T>();
            var initialList = list[0];
            foreach (var item in list) initialList = initialList.Intersect(item).ToList();
            return initialList;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}