namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IGarbageRemover
{
    List<string> Remove(List<string> wordsList);
}