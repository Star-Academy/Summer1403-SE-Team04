using SearchAPI;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;using SearchAPI.Controllers.search;using SearchAPI.Controllers.search.Abstraction;

    var builder = WebApplication.CreateBuilder(args);
    
    var serviceProvider = new ServiceBuilder(builder).Build();
    var indicesList = new List<string> { Resources.DocumentsPath };
    IAdvancedProcessor advancedQuerySearcher = serviceProvider.GetRequiredService<IAdvancedProcessor>();

    var reformatres = new List<IStringReformater>()
    {
        serviceProvider.GetRequiredKeyedService<IStringReformater>("root"),
        serviceProvider.GetRequiredKeyedService<IStringReformater>("lower")
    };

    serviceProvider.GetRequiredService<IInitializer>().Init(indicesList, reformatres);
    new AspBuilder(builder).Build();
