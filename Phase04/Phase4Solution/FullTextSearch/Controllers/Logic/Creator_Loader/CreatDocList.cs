using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearch.Controllers.Logic.Creator_Loader;

public class CreatDocList(IDocumentLoader documentLoader,IDocCatcher docCatcher)
{
    public void CreatDoc(string directoryPath)
    {
        var reformaters = new List<IStringReformater> { new ToLower(), new ToRoot() };
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, reformaters);
    }
}