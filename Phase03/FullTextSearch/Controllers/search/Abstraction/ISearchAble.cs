namespace FullTextSearch.Controllers.search.Abstraction;

public interface ISearchAble
{
    public IEnumerable<string> Search(string query);
}