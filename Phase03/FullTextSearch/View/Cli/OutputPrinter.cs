namespace FullTextSearch.View.Cli;

public class OutputPrinter : IOutputRenderer
{ 
    public void Render(List<string> output)
    {
        output.ForEach(Console.WriteLine);
    }

    public void Render(string output)
    {
        Render(new List<string> { output });
    }
}