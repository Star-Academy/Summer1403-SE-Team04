using SearchAPI.Controllers.Logic.Abstraction;

namespace SearchAPI.Controllers.Abstraction;

public interface IInitializer
{
    void Init(List<string> directoryList,List<IStringReformater> reformaters);
}