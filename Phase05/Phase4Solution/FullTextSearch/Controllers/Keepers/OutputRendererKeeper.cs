using FullTextSearch.View;

namespace FullTextSearch.Controllers.Keepers;

public class OutputRendererKeeper
{
    private static OutputRendererKeeper _outputRendererKeeper;

    private OutputRendererKeeper()
    {
    }

    public static OutputRendererKeeper Instance => _outputRendererKeeper ??= new OutputRendererKeeper();
    public IOutputRenderer OutputRenderer { get; set; }
}