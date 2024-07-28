using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.View;

namespace FullTextSearch.Controllers;

public class Initializer : IInitializer
{
    private static Initializer? _initializer;

    private Initializer()
    {
    }

    public static Initializer InitializerInstance => _initializer ??= new Initializer();

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