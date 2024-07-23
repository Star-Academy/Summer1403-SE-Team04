using FullTextSearch;

internal class Program
{
    private static void Main()
    {
        var listOfTheDocument = new DocumentLoader().LoadDocuments();
        
        foreach (var doc in new WordSearcher
                         (new InvertedIndex(listOfTheDocument)).FindDocuments(Console.ReadLine()))
            Console.WriteLine(doc);
    }
}