namespace FullTextSearch.Controllers.Abstraction;

public interface IQueryReceiver
{
    void GetQuery(string query);
}