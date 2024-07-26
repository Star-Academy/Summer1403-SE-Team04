namespace FullTextSearch.Control;

public class Controller
{
    private static Controller? _controller;
    public static Controller Instance => _controller ??= new Controller();

    public void GetQuery(string query)
    {
        QuerySearcher.Instance.ProcessQuery(query);
    }
}