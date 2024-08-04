using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IInvertedIndexLoader
{
    List<InvertedIndex>? Load();
}