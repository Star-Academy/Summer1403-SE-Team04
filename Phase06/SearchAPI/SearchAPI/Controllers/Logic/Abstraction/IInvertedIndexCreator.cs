namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IInvertedIndexCreator
{
    void CreateInvertedIndex(string directoryPath);
}