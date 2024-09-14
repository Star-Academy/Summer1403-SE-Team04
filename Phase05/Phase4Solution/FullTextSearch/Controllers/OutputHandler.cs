using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.View;

namespace FullTextSearch.Controllers;

public class OutputHandler(IOutputRenderer renderer) : IOutputHandler
{
    public void SendOutput(List<string> output)
    {
        if (!output.Any())
        {
            renderer.Render(Resources.WordNotFoundMessage);
            return;
        }

        renderer.Render(output);
    }
}