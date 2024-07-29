using FullTextSearch;
using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.View.Cli;

internal class Program
{
    private static void Main()
    {
        var inputListener = new CliInputListener();
        var outputPrinter = new OutputPrinter();
        var docLoader = new DocumentLoader(new DocBuilder(new TxtReader()),new SmallWordsRemover());
        var indicesList = new List<string> { Resources.DocumentsPath };
        var indexCreator = new InvertedIndexCreator(new InvertedIndexWriter(),docLoader) ;
        new ServiceStartupInitializer(inputListener, outputPrinter,indexCreator).Init(indicesList);
    }
}