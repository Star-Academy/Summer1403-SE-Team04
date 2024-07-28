using FullTextSearch;
using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.View.Cli;

internal class Program
{
    private static void Main()
    {
        var inputListener = CliInputListener.CliInputListenerInstance;
        var outputPrinter = OutputPrinter.OutputPrinterInstance;
        var indicesList = new List<string> { Resources.DocumentsPath };
        var indexCreator = InvertedIndexCreator.InvertedIndexCreatorInstance;
        var docLoader = DocumentLoader.Instance;
        Initializer.InitializerInstance.Init(indicesList, inputListener, outputPrinter,indexCreator, docLoader);
    }
}