using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;

namespace FullTextSearch.View.Cli;

public class CliInputListener : IInputListener
{
    private const string ExitCommand = "exit";
    private static CliInputListener? _cliInputListener;

    private CliInputListener()
    {
    }

    public static CliInputListener CliInputListenerInstance => _cliInputListener ??= new CliInputListener();

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
            QueryReceiver.Instance.GetQuery(query, new InvertedIndexLoader());
            OutputRendererKeeper.Instance.OutputRenderer.Render(
                Resources.EnterWordMessage);
            query = Console.ReadLine();
        }
    }
}