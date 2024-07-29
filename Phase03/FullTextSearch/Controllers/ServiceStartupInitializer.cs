using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.View;

namespace FullTextSearch.Controllers;

public class ServiceStartupInitializer : IInitializer
{
    private static ServiceStartupInitializer? _initializer;

    private ServiceStartupInitializer()
    {
    }

    public static ServiceStartupInitializer ServiceStartupInitializerInstance => _initializer ??= new ServiceStartupInitializer();

    public void Init(List<string> directoryList, IInputListener inputListener,
        IOutputRenderer outputRenderer, IInvertedIndexCreator indexCreator, IDocumentLoader docLoader)
    {
        directoryList.ForEach(path =>
            indexCreator.CreateInvertedIndex(path, new InvertedIndexWriter(),
                docLoader));
        
        InputListenerKeeper.Instance.InputListener = inputListener;
        OutputRendererKeeper.Instance.OutputRenderer = outputRenderer;
        inputListener.InputListenerRegister();
    }
}