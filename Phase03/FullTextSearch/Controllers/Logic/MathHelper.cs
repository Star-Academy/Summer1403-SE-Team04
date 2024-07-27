namespace FullTextSearch.Control.Logic;

public static class MathHelper
{
    public static List<T> Union<T>(this List<List<T>> enumberList)
    {
        try
        {
            return !enumberList.Any() ? new List<T>() : enumberList.Aggregate((current, next) => current.Union(next).ToList());
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<T> Intersect<T>(this List<List<T>> enumerable)
    {
        try
        {
            return !enumerable.Any() ? new List<T>() : enumerable.Aggregate((current, next) => current.Intersect(next).ToList());
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}