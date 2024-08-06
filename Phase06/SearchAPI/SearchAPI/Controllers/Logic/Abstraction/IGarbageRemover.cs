namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IGarbageRemover
{
    List<string> Remove(List<string> wordsList);
}