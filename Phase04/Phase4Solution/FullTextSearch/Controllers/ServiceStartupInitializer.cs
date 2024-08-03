using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.View;

namespace FullTextSearch.Controllers;

public class ServiceStartupInitializer(
    IInputListener inputListener,
    IOutputRenderer outputRenderer,
    IAdvancedInvertedIndexCreator indexCreator
) : IInitializer
{
    public void Init(List<string> directoryList)
    {
        File.WriteAllText(Resources.InvertedIndexDataPath, string.Empty);
        directoryList.ForEach(path => indexCreator.CreateAdvancedInvertedIndex(path));
        InputListenerKeeper.Instance.InputListener = inputListener;
        OutputRendererKeeper.Instance.OutputRenderer = outputRenderer;
        inputListener.InputListenerRegister();
    }
}