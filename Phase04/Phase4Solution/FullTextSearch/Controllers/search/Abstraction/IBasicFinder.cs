namespace FullTextSearch.Controllers.search.Abstraction;

public interface IBasicFinder : IFinder
{
    IEnumerable<string>? Find(string word);

}