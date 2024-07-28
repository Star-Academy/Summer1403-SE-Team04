﻿using FullTextSearch;
using FullTextSearch.Controllers;
using FullTextSearch.View.Cli;

internal class Program
{
    private static void Main()
    {
        Initializer.InitializerInstance.Init(new List<string> { Resources.DocumentsPath },
            CliInputListener.CliInputListenerInstance, OutputPrinter.OutputPrinterInstance);
    }
}