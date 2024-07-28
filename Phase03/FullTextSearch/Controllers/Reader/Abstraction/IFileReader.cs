using System.Collections;
using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Reader.Abstraction;

public interface IFileReader
{
    IEnumerable<string> Read(string path,IGarbageRemover remover);
}