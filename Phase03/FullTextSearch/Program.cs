using FullTextSearch;
using FullTextSearch.Control;

internal class Program
{
    private static void Main()
    {
       Initializer.InitializerInstance.Init(new List<string>(){Resources.documentsPath});
    }
}