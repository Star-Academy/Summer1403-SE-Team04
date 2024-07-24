
using FullTextSearch.Control.Logic;
using FullTextSearch.View.Cli;

namespace FullTextSearch.Control;

public class Initializer
{
    private static Initializer? _initializer;
    public static Initializer InitializerInstance => _initializer ??= new Initializer();

    public void Init(List<string> directoryList)
    {
        directoryList.ForEach(path => InvertedIndexBuilder.InvertedIndexBuilderInstance.BuildInvertedIndex(path));
        CliInputListener.CliInputListenerInstance.InputListenerRegister();
    }
}