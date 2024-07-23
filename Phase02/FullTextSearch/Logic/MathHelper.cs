namespace FullTextSearch;

public static class MathHelper
{
    public static List<T> Union<T>(this List<List<T>> list)
    {
        try
        {
            if (list.Count == 0) return new List<T>();
            var list1 = new List<T>();
            foreach (var item in list) list1 = list1.Union(item).ToList();

            return list1;
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
            var list1 = list[0];
            foreach (var item in list) list1 = list1.Intersect(item).ToList();
            return list1;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}