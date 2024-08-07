using FullTextSearch;
using SearchAPI.Controllers;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.Logic.Creator_Loader;
using SearchAPI.Controllers.Logic.DocumentsLoader;
using SearchAPI.Controllers.Reader;
using Microsoft.OpenApi.Models;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.StringProcessor;
using SearchAPI.Controllers.Reader.Abstraction;
using SearchAPI.Controllers.search;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.SearchStrategy;
var serviceProvider = new ServiceCollection().AddSingleton<IDocCatcher, DocCatcher>()
    .AddSingleton<IAdvancedInvertedIndexCatcher, AdvanceInvertedIndexCatcher>()
    .AddSingleton<IDocumentLoader, DocumentLoader>()
    .AddSingleton<IInitializer, ServiceStartupInitializer>()
    .AddSingleton<IDocBuilder, DocBuilder>()
    .AddSingleton<IGarbageRemover, SmallWordsRemover>()
    .AddKeyedSingleton<IStringReformater, ToLower>("lower")
    .AddKeyedSingleton<IStringReformater, ToRoot>("root")
    .AddSingleton<ITxtReader, TxtReader>()
    .AddSingleton<IAdvancedFinder,AdvancedDocFinder>()
    .AddSingleton<IAdvancedProcessor, AdvancedQuerySearcher>()
    .AddSingleton<ISearchAble,WordSearcher>()
    .AddSingleton<ISearchStrategy, AdvancedStrategy>()
    .BuildServiceProvider();

var docCatcher = new DocCatcher();
var advIndexcatcher = new AdvanceInvertedIndexCatcher();
var docLoader =  serviceProvider.GetRequiredService<IDocumentLoader>();
var a = docLoader.LoadDocumentsList(Resources.DocumentsPath,new List<IStringReformater>());
var indicesList = new List<string> { Resources.DocumentsPath };
// var indexCreator = new InvertedIndexCreator(cacher, docLoader);
new ServiceStartupInitializer(
    new AdvanceInvertedIndexCreator(docCatcher, advIndexcatcher, docLoader)).Init(indicesList);


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "fullTextSearchApi", Version = "v1" })
);
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FullTextSearch"));
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();