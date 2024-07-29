using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.search.Abstraction;

public interface IFinder
{ IEnumerable<string>? Find(string query);
}