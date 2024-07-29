using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Controllers.search;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers;

public class QueryReceiver(IInvertedIndexLoader loader) : IQueryReceiver
{
    public void GetQuery(string query)
    { 
        new QuerySearcher(loader).ProcessQuery(query);
    }
}