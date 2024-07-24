namespace FullTextSearch.View.Cli;

public class OutputPrinter : IOutputRenderer
{
    private static OutputPrinter? _outputPrinter;
    public static OutputPrinter OutputPrinterInstance => _outputPrinter ??= new OutputPrinter();
    private OutputPrinter(){}
    public void Present(List<string> output)
    {
        output.ForEach(Console.WriteLine);
    }
}