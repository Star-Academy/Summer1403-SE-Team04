using FullTextSearch.Controllers;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using Microsoft.OpenApi.Models;


var docCatcher = new DocCatcher();
var advIndexcatcher = new AdvanceInvertedIndexCatcher();
var docLoader = new DocumentLoader(new DocBuilder(new TxtReader(), docCatcher), new SmallWordsRemover());
var indicesList = new List<string> { Resources.DocumentsPath };
// var indexCreator = new InvertedIndexCreator(cacher, docLoader);
var inputListener = new CliInputListener(advIndexcatcher, docCatcher);
var outputPrinter = new OutputPrinter();
new ServiceStartupInitializer(inputListener, outputPrinter,
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