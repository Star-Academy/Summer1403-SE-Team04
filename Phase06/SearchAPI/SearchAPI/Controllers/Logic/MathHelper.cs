namespace SearchAPI.Controllers.Logic;

public static class MathHelper
{
    public static List<T> Union<T>(this List<List<T>>? enumberList)
    {
        if (!enumberList.Any() || enumberList == null)
            return new List<T>();

        return enumberList.Aggregate((current, next) => current.Union(next).ToList());
    }

    public static List<T> Intersect<T>(this List<List<T>> enumerable)
    {
        if (!enumerable.Any() || enumerable == null)
            return new List<T>();

        return enumerable.Aggregate((current, next) => current.Intersect(next).ToList());
    }
}