using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IInvertedIndexWriter
{
    void Write(InvertedIndex index);
}