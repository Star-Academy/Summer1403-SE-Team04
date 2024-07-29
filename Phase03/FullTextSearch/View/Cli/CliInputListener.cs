using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;

namespace FullTextSearch.View.Cli;

public class CliInputListener : IInputListener
{
    private const string ExitCommand = "exit";
    public void InputListenerRegister()
    {
        GetInputFromCli();
    }

    private void GetInputFromCli()
    {
        OutputRendererKeeper.Instance.OutputRenderer.Render(
            Resources.EnterWordMessage);
        var query = Console.ReadLine();
        while (query != ExitCommand)
        { 
            new QueryReceiver(new InvertedIndexLoader()).GetQuery(query);
            OutputRendererKeeper.Instance.OutputRenderer.Render(
                Resources.EnterWordMessage);
            query = Console.ReadLine();
        }
    }
}