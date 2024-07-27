namespace FullTextSearch.Control;

public class QueryReceiver
{
    private static QueryReceiver? _queryReceiver;
    public static QueryReceiver Instance => _queryReceiver ??= new QueryReceiver();

    public void GetQuery(string query)
    {
        QuerySearcher.Instance.ProcessQuery(query);
    }
}