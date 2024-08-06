using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Abstraction;

public interface IInvertedIndexCatcher : IInvertedIndexWriter, IInvertedIndexLoader
{
}