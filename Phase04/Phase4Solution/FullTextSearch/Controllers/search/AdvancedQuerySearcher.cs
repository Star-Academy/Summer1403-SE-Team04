using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.search.Abstraction;

namespace FullTextSearch.Controllers.search;
public class AdvancedQuerySearcher(IAdvancedInvertedIndexCatcher invertedIndexLoader) : IAdvancedProcessor
{
    public void ProcessQuery(string query)
    {
        
    }
}