namespace SearchAPI.Controllers.Abstraction;

public interface IInitializer
{
    void Init(List<string> directoryList);
}