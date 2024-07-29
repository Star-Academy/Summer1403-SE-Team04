using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IDocBuilder
{
    Document Build(string docPath, IDocReader docReader);
}