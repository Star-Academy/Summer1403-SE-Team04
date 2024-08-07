using Microsoft.AspNetCore.Mvc;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;
using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Logic.Creator_Loader;

public class InvertedIndexCreator([FromServices]IInvertedIndexCatcher catcher,[FromServices] IDocumentLoader documentLoader) : IInvertedIndexCreator
{
    public void CreateInvertedIndex(string directoryPath, List<IStringReformater> reformaters)
    {
        var documents = documentLoader
            .LoadDocumentsList(directoryPath, reformaters);
        var newIndex = new InvertedIndex(documents, directoryPath);
        catcher.Write(newIndex);
    }
}