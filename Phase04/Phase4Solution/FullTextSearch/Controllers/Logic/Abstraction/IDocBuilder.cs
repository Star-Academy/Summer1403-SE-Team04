using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IDocBuilder
{
    Document Build(string docPath);
}