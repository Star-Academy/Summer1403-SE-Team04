
using FullTextSearch.Control.Keepers;
using FullTextSearch.Control.Logic;
using FullTextSearch.Controller.Logic;
using FullTextSearch.View;

namespace FullTextSearch.Control;

public class Initializer
{
    private static Initializer? _initializer;
    public static Initializer InitializerInstance => _initializer ??= new Initializer();

    public void Init(List<string> directoryList , IInputListener inputListener, IOutputRenderer outputRenderer)
    {
        directoryList.ForEach(path => InvertedIndexBuilder.InvertedIndexBuilderInstance.BuildInvertedIndex(path));
        InputListenerKeeper.Instance.InputListener = inputListener;
        OutputRendererKeeper.Instance.OutputRenderer = outputRenderer;
        inputListener.InputListenerRegister();
    }
    
}