using FullTextSearch.Control;

namespace FullTextSearch.View.Cli;

public class CliInputListener : IInputListener
{
    private static CliInputListener? _cliInputListener;
    public static CliInputListener CliInputListenerInstance => _cliInputListener ??= new CliInputListener();
    private CliInputListener(){}
    private void GetInputFromCli()
    {
        var query = Console.ReadLine();
        while (query != "exit")
        {
            Controller.ControllerInstance.GetQuery(query);
            query = Console.ReadLine();
        }
    }

    public void InputListenerRegister()
    {
        GetInputFromCli();
    }
}