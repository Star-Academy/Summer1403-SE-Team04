namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IInvertedIndexBuilder
{
    void BuildInvertedIndex(string directoryPath);
}