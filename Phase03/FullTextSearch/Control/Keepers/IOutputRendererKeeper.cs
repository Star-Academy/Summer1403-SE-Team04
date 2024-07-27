using FullTextSearch.View;

namespace FullTextSearch.Control.Keepers;

public class OutputRendererKeeper
{
    private static OutputRendererKeeper _outputRendererKeeper;
    public static OutputRendererKeeper Instance => _outputRendererKeeper ??= new OutputRendererKeeper();
    public IOutputRenderer OutputRenderer { get; set; }
    private OutputRendererKeeper(){}
}