using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class CreatDocList([FromServices]IDocumentLoader documentLoader)
{
    public void CreatDoc(string directoryPath,List<IStringReformater> reformaters)
    {
        var documents = documentLoader
            .LoadDocumentsList(directoryPath,reformaters);
    }
}