using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IInvertedIndexLoader
{
    List<InvertedIndex>? Load();
}