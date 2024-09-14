namespace FullTextSearch.Controllers.search.Abstraction;

public interface IFinder
{
    List<string>? Find(string word);
}