namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IAdvancedInvertedIndexCreator
{
    void CreateAdvancedInvertedIndex(string directoryPath);
}