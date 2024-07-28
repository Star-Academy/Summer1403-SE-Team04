using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Abstraction;

public interface IQueryReceiver
{
    void GetQuery(string query, IInvertedIndexLoader loader);
}