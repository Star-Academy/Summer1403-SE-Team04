namespace FullTextSearch.View.Cli;

public class OutputPrinter : IOutputRenderer
{
    private static OutputPrinter? _outputPrinter;

    private OutputPrinter()
    {
    }

    public static OutputPrinter OutputPrinterInstance => _outputPrinter ??= new OutputPrinter();

    public void Render(List<string> output)
    {
        output.ForEach(Console.WriteLine);
    }

    public void Render(string output)
    {
        Render(new List<string> { output });
    }
}