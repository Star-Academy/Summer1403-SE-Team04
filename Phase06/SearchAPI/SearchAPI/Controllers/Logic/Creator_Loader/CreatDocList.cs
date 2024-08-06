using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class CreatDocList(IDocumentLoader documentLoader, IDocCatcher docCatcher)
{
    public void CreatDoc(string directoryPath)
    {
        var reformaters = new List<IStringReformater> { new ToLower(), new ToRoot() };
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, reformaters);
    }
}