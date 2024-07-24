using FullTextSearch;
using FullTextSearch.DataStructure;
using FullTextSearch.Logic;

internal class Program
{
    private static void Main()
    {
        var listOfTheDocument = DocumentLoader.DocumentLoaderInstance.LoadDocuments();
        foreach (var doc in new WordSearcher
                         (new InvertedIndex(listOfTheDocument)).FindDocuments(Console.ReadLine()))
            Console.WriteLine(doc);
    }
}