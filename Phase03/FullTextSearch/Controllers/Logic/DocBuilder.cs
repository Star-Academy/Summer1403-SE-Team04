using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Reader.Abstraction;
using FullTextSearch.Model;

namespace FullTextSearch.Controllers.Logic;

public class DocBuilder : IDocBuilder
{
    private static DocBuilder _docBuilder;
    public static DocBuilder Instance => _docBuilder ??= new DocBuilder();

    public Document Builed(string docPath ,IDocReader docReader)
    {
        return new Document(docPath, docReader.Read(docPath, new SmallWordsRemover()));
    }
}