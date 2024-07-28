using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
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

    public void Init(List<string> directoryList, IInputListener inputListener, IOutputRenderer outputRenderer)
    {
        directoryList.ForEach(path =>
            InvertedIndexCreator.InvertedIndexCreatorInstance.CreateInvertedIndex(path, new InvertedIndexWriter(),
                DocumentLoader.Instance));
        InputListenerKeeper.Instance.InputListener = inputListener;
        OutputRendererKeeper.Instance.OutputRenderer = outputRenderer;
        inputListener.InputListenerRegister();
    }
}