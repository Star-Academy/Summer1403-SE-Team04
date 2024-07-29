namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IInvertedIndexCreator
{
    void CreateInvertedIndex(string directoryPath, IInvertedIndexWriter writer, IDocumentLoader documentLoader);
}