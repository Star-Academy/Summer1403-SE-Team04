using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface IInvertedIndexLoader
{
    List<InvertedIndex>? Load();
}