
using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Keepers;

namespace FullTextSearch.View.Cli;

public class CliInputListener : IInputListener
{
    private static CliInputListener? _cliInputListener;
    public static CliInputListener CliInputListenerInstance => _cliInputListener ??= new CliInputListener();
    private CliInputListener(){}
    private void GetInputFromCli()
    {
        OutputRendererKeeper.Instance.OutputRenderer.Render("Enter your word (if you want to finish the program enter 'exit') : ");
        var query = Console.ReadLine();
        while (query != "exit")
        {
            QueryReceiver.Instance.GetQuery(query);
            OutputRendererKeeper.Instance.OutputRenderer.Render("Enter your word (if you want to finish the program enter 'exit') : ");
            query = Console.ReadLine();
        }
    }

    public void InputListenerRegister()
    {
        GetInputFromCli();
    }
}