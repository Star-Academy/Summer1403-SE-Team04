using SearchAPI.Model;

namespace SearchAPI.Controllers.Logic.Abstraction;

public interface IDocBuilder
{
    Document Build(string docPath);
}