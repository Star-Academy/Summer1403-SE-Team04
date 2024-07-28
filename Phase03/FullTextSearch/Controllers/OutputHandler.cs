using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;

namespace FullTextSearch.Controllers;

public class OutputHandler : IOutputHandler
{
    private static OutputHandler? _outputHandler;
    public static OutputHandler Instance => _outputHandler ??= new OutputHandler();
    private OutputHandler(){}
    public void SendOutput(List<string> output)
    {
        if (!output.Any())
        {
            OutputRendererKeeper.Instance.OutputRenderer.Render("Nothing was found for your word");
            return;
        }
        OutputRendererKeeper.Instance.OutputRenderer.Render(output);
    }
}