using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers.Abstraction;

public interface IInvertedIndexCatcher : IInvertedIndexWriter, IInvertedIndexLoader
{
}