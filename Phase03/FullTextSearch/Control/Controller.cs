using FullTextSearch.Control.Logic;
using FullTextSearch.Model.DataStructure;
using FullTextSearch.View.Cli;

namespace FullTextSearch.Control;

public class Controller
{
    private static Controller? _controller;
    public static Controller ControllerInstance => _controller ??= new Controller();
    public void GetQuery(string query)
    {
        ProcessQuery(query);
    }

    private void ProcessQuery(string query)
    {
        var result =
        InvertedIndex.InvertedIndicesList.Select(invertedIndex =>
            new WordSearcher(invertedIndex).FindDocuments(query)).ToList();
        SendOutput(result.Union());
    }

    private void SendOutput(List<string> output)
    {
        if (output.Count == 0)
        {
            OutputPrinter.OutputPrinterInstance.Present("Nothing was not found for your word");
            return;
        }
        OutputPrinter.OutputPrinterInstance.Present(output);
    }
}