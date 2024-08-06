namespace SearchAPI.Controllers.search.Abstraction;

public interface IProcessor
{
    List<string> ProcessQuery(string query);
}