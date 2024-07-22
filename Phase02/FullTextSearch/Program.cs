using FullTextSearch;

class Program
{
    static void Main()
    {
        var listOfTheDocument = DocReader.ReadDocs()
            .Select(doc => new Document(doc.DocName, 
                    doc.DocWords.Select
                        (w => w.FixWordFormat())
                        .ToList().RemoveEmptyCells())).ToList();
        var invert = new InvertedIndex();
        invert.BuildInvertedIndex(listOfTheDocument);
        Console.WriteLine(invert);
        // search func
        // input  + call search function
    }
}