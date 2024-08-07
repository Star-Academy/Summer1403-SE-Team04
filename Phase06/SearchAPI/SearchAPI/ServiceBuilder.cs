using Microsoft.EntityFrameworkCore;
using SearchAPI.Controllers;
using SearchAPI.Controllers.Abstraction;
using SearchAPI.Controllers.Logic;
using SearchAPI.Controllers.Logic.Abstraction;
using SearchAPI.Controllers.Logic.Creator_Loader;
using SearchAPI.Controllers.Logic.DocumentsLoader;
using SearchAPI.Controllers.Logic.StringProcessor;
using SearchAPI.Controllers.Reader;
using SearchAPI.Controllers.Reader.Abstraction;
using SearchAPI.Controllers.search;
using SearchAPI.Controllers.search.Abstraction;
using SearchAPI.Controllers.search.SearchStrategy;
using SearchAPI.Model.Database;

namespace SearchAPI;

public class ServiceBuilder(WebApplicationBuilder builder)
{
    public ServiceProvider Build()
    {
        var co = Environment.GetEnvironmentVariable("Server=localhost;Port=5432;Database=FullTextSearchDb;User Id=postgres;Password=1274542332Mz;");
        return builder.Services.AddDbContext<FullTextSearchDbContext>(o =>
                o.UseNpgsql(co))
            .AddSingleton<IDocCatcher, DocCatcher>()
            .AddSingleton<IAdvancedInvertedIndexCatcher, AdvanceInvertedIndexCatcher>()
            .AddSingleton<IAdvancedInvertedIndexCreator, AdvanceInvertedIndexCreator>()
            .AddSingleton<IDocumentLoader, DocumentLoader>()
            .AddSingleton<IInitializer, ServiceStartupInitializer>()
            .AddSingleton<IDocBuilder, DocBuilder>()
            .AddSingleton<IGarbageRemover, SmallWordsRemover>()
            .AddKeyedSingleton<IStringReformater, ToLower>("lower")
            .AddKeyedSingleton<IStringReformater, ToRoot>("root")
            .AddSingleton<ITxtReader, TxtReader>()
            .AddSingleton<IAdvancedProcessor, AdvancedQuerySearcher>()
            .AddSingleton<IAdvancedFinder, AdvancedDocFinder>()
            .AddSingleton<ISearchStrategy, AdvancedStrategy>()
            .BuildServiceProvider();
    }
}