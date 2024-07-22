using FullTextSearch;
    
class Program
{
    static void Main()
    {
        var listOfTheDocument = new DocReader().ReadDocs()
            .Select(doc => new Document(doc.DocName,
                doc.DocWords.Select
                        (w => w.FixWordFormat())
                    .ToList().RemoveEmptyCells())).ToList();
        foreach (var doc in new WordSearcher
                     (new InvertedIndex(listOfTheDocument))
                     .FindDocuments(Console.ReadLine()))
        {
            Console.WriteLine(doc);
        }
    }
}