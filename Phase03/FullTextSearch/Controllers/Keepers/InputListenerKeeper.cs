using FullTextSearch.View;

namespace FullTextSearch.Controllers.Keepers;

public class InputListenerKeeper
{
    private static InputListenerKeeper _inputListenerKeeper;
    public static InputListenerKeeper Instance => _inputListenerKeeper ??= new InputListenerKeeper();
    public IInputListener InputListener { get; set; }
    private InputListenerKeeper(){}
}