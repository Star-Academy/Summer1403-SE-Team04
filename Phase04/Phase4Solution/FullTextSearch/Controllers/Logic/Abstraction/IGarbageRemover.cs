namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IGarbageRemover
{
    IEnumerable<string> Remove(IEnumerable<string> wordsList);
}