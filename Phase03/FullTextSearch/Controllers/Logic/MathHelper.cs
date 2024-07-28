namespace FullTextSearch.Controllers.Logic;

public static class MathHelper
{
    public static List<T> Union<T>(this List<List<T>> enumberList)
    {
        try
        {
            if (!enumberList.Any()) 
                return new List<T>();
            
            return enumberList.Aggregate((current, next) => current.Union(next).ToList());
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
            if (!enumerable.Any())
                return new List<T>();
            
            return enumerable.Aggregate((current, next) => current.Intersect(next).ToList());
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}