using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.View;

namespace FullTextSearch.Controllers;

public class ServiceStartupInitializer (
    IInputListener inputListener,
    IOutputRenderer outputRenderer,
    IInvertedIndexCreator indexCreator
    ) :  IInitializer
{ 
    public void Init(List<string> directoryList)
    {
        File.WriteAllText(Resources.InvertedIndexDataPath, string.Empty);
        directoryList.ForEach(path => indexCreator.CreateInvertedIndex(path));
        InputListenerKeeper.Instance.InputListener = inputListener;
        OutputRendererKeeper.Instance.OutputRenderer = outputRenderer;
        inputListener.InputListenerRegister();
    }
}