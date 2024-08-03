namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IAdvanceInvertedIndexCreator
{
    void CreateAdvanceInvertedIndex(string directoryPath);
}