using FullTextSearch.View.Cli;

namespace FullTextSearch.Control;

public class OutputHandler
{
    private static OutputHandler? _outputHandler;
    public static OutputHandler Instance => _outputHandler ??= new OutputHandler();

    public void SendOutput(List<string> output)
    {
        if (!output.Any())
        {
            OutputPrinter.OutputPrinterInstance.Render("Nothing was found for your word");
            return;
        }
        OutputPrinter.OutputPrinterInstance.Render(output);
    }
}