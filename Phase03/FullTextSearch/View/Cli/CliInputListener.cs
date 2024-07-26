using FullTextSearch.Control;

namespace FullTextSearch.View.Cli;

public class CliInputListener : IInputListener
{
    private static CliInputListener? _cliInputListener;
    public static CliInputListener CliInputListenerInstance => _cliInputListener ??= new CliInputListener();
    private CliInputListener(){}
    private void GetInputFromCli()
    {
        OutputPrinter.OutputPrinterInstance.Render("Enter your word (if you want to finish the program enter 'exit') : ");
        var query = Console.ReadLine();
        while (query != "exit")
        {
            Controller.ControllerInstance.GetQuery(query);
            OutputPrinter.OutputPrinterInstance.Render("Enter your word (if you want to finish the program enter 'exit') : ");
            query = Console.ReadLine();
        }
    }

    public void InputListenerRegister()
    {
        GetInputFromCli();
    }
}