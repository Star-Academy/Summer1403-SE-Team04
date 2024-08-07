using FullTextSearch;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;

var serviceProvider = new ServiceBuilder(new ServiceCollection()).Build();
var indicesList = new List<string> { Resources.DocumentsPath };
var reformatres = new List<IStringReformater>()
{
    serviceProvider.GetRequiredKeyedService<IStringReformater>("root"),
    serviceProvider.GetRequiredKeyedService<IStringReformater>("lower")
};
serviceProvider.GetRequiredService<IInitializer>().Init(indicesList, reformatres);
new AspBuilder(WebApplication.CreateBuilder(args)).Build();