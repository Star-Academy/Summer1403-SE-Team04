namespace SearchAPI.Controllers.search.Abstraction;

public interface IFinder
{
    List<string>? Find(string word);
}