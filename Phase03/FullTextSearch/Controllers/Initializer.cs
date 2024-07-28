using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.View;

namespace FullTextSearch.Controllers;

public class Initializer : IInitializer
{
    private static Initializer? _initializer;
    public static Initializer InitializerInstance => _initializer ??= new Initializer();

    private Initializer()
    {
    }

    public void Init(List<string> directoryList , IInputListener inputListener, IOutputRenderer outputRenderer)
    {
        directoryList.ForEach(path => InvertedIndexBuilder.InvertedIndexBuilderInstance.BuildInvertedIndex(path));
        InputListenerKeeper.Instance.InputListener = inputListener;
        OutputRendererKeeper.Instance.OutputRenderer = outputRenderer;
        inputListener.InputListenerRegister();
    }
    
}