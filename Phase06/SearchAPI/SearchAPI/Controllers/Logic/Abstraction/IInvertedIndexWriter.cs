using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IInvertedIndexWriter
{
    void Write(InvertedIndex index);
}