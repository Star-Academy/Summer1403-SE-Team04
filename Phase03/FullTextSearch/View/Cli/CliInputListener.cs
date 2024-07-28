using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic;

namespace FullTextSearch.View.Cli;

public class CliInputListener : IInputListener
{
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
            "Enter your word (if you want to finish the program enter 'exit') : ");
        var query = Console.ReadLine();
        while (query != "exit")
        {
            QueryReceiver.Instance.GetQuery(query, new InvertedIndexLoader());
            OutputRendererKeeper.Instance.OutputRenderer.Render(
                "Enter your word (if you want to finish the program enter 'exit') : ");
            query = Console.ReadLine();
        }
    }
}