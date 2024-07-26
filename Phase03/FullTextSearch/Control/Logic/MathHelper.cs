namespace FullTextSearch.Control.Logic;

public static class MathHelper
{
    public static List<T> Union<T>(this List<List<T>> list)
    {
        try
        {
            return !list.Any() ? new List<T>() : list.Aggregate((current, next) => current.Union(next).ToList());
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
            return !list.Any() ? new List<T>() : list.Aggregate((current, next) => current.Intersect(next).ToList());
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}