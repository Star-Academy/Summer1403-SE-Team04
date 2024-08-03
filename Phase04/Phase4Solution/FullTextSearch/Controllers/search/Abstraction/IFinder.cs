namespace FullTextSearch.Controllers.search.Abstraction;

public interface IFinder
{
    IEnumerable<string>? Find(string word);
}