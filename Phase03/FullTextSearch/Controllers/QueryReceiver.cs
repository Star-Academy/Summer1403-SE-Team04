using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers;

public class QueryReceiver(IProcessor processor) : IQueryReceiver
{
    public void GetQuery(string query)
    {
        processor.ProcessQuery(query);
    }
}