namespace FullTextSearch.Controllers.search.Abstraction;

public interface IBasicFinder : IFinder
{
    List<string>? Find(string word);

}