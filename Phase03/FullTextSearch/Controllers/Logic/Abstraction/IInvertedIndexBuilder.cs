namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IInvertedIndexBuilder
{
    void BuildInvertedIndex(string directoryPath, IInvertedIndexWriter writer,IDocumentLoader documentLoader);
}