using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface IProcessor
{
     void ProcessQuery(string query, IInvertedIndexLoader loader);
}