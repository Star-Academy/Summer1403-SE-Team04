using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.View.Cli;

namespace FullTextSearch;

internal class Program
{
    private static void Main()
    {
        // var cacher = new InvertedIndexCatcher();
        var docCatcher = new DocCatcher();
        var advIndexcatcher = new AdvanceInvertedIndexCatcher();
        var docLoader = new DocumentLoader(new DocBuilder(new TxtReader(), docCatcher), new SmallWordsRemover());
        var indicesList = new List<string> { Resources.DocumentsPath };
        // var indexCreator = new InvertedIndexCreator(cacher, docLoader);
        var inputListener = new CliInputListener(advIndexcatcher, docCatcher);
        var outputPrinter = new OutputPrinter();
        new ServiceStartupInitializer(inputListener, outputPrinter,
            new AdvanceInvertedIndexCreator(docCatcher, advIndexcatcher, docLoader)).Init(indicesList);
    }
}