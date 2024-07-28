using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IDocBuilder
{
    Document Builed(string docPath, IDocReader docReader);
}