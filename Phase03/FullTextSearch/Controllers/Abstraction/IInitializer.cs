using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.View;

namespace FullTextSearch.Controllers.Abstraction;

public interface IInitializer
{
    void Init(List<string> directoryList, IInputListener inputListener,
        IOutputRenderer outputRenderer, IInvertedIndexCreator indexCreator, IDocumentLoader docLoader);
}