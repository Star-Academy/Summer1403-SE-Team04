using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;

namespace FullTextSearch.Controllers;

public class OutputHandler : IOutputHandler
{
    private static OutputHandler? _outputHandler;

    private OutputHandler()
    {
    }

    public static OutputHandler Instance => _outputHandler ??= new OutputHandler();

    public void SendOutput(List<string> output)
    {
        if (!output.Any())
        {
            OutputRendererKeeper.Instance.OutputRenderer.Render(Resources.WordNotFoundMessage);
            return;
        }

        OutputRendererKeeper.Instance.OutputRenderer.Render(output);
    }
}