namespace SearchAPI.Controllers.search.Abstraction;

public interface ISearchStrategy
{
    List<string> Search(string query);
}