using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search;

namespace FullTextSearch.Controllers;

public class QueryReceiver : IQueryReceiver
{
    private static QueryReceiver? _queryReceiver;
    public static QueryReceiver Instance => _queryReceiver ??= new QueryReceiver();

    public void GetQuery(string query, IInvertedIndexLoader loader)
    {
        QuerySearcher.Instance.ProcessQuery(query, loader);
    }
}