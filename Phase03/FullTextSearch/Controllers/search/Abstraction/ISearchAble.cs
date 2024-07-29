namespace FullTextSearch.Controllers.search.Abstraction;

public interface ISearchAble
{ 
    IEnumerable<string> Search(string query);
}