using SearchAPI;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;using SearchAPI.Controllers.search;using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Model;
using SearchAPI.Model.DataStructure;

var builder = WebApplication.CreateBuilder(args);
    
    var serviceProvider = new ServiceBuilder(builder).Build();
    Console.WriteLine(" firs" +serviceProvider.GetRequiredService<IAdvancedInvertedIndexCatcher>().GetHashCode());
    var indicesList = new List<string> { Resources.DocumentsPath };
    IAdvancedProcessor advancedQuerySearcher = serviceProvider.GetRequiredService<IAdvancedProcessor>();
    serviceProvider.GetService<IAdvancedInvertedIndexCatcher>().Write(new AdvancedInvertedIndex(new List<Document>(), ""));
    Console.WriteLine(" firs" +serviceProvider.GetRequiredService<IAdvancedInvertedIndexCatcher>().GetHashCode());
    var reformatres = new List<IStringReformater>()
    {
        serviceProvider.GetRequiredKeyedService<IStringReformater>("root"),
        serviceProvider.GetRequiredKeyedService<IStringReformater>("lower")
    };

    serviceProvider.GetRequiredService<IInitializer>().Init(indicesList, reformatres);
    new AspBuilder(builder).Build();
