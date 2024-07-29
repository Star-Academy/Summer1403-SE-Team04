using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers;

public class QueryReceiver(IProcessor processor) : IQueryReceiver
{
    public void GetQuery(string query)
    {
        processor.ProcessQuery(query);
    }
}