using System.Collections;
using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface ITxtReader
{
    IEnumerable<string> Read(string path);
}