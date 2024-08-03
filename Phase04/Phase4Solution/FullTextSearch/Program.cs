﻿using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.View.Cli;

namespace FullTextSearch;

internal class Program
{
    private static void Main()
    {
        var cacher = new InvertedIndexChather();
        var docLoader = new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover());
        var indicesList = new List<string> { Resources.DocumentsPath };
        var indexCreator = new InvertedIndexCreator(cacher, docLoader);
        var inputListener = new CliInputListener(cacher);
        var outputPrinter = new OutputPrinter();
        new ServiceStartupInitializer(inputListener, outputPrinter, indexCreator).Init(indicesList);
    }
}