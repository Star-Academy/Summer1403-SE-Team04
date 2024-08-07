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

namespace SearchAPI;

public class ServiceBuilder(WebApplicationBuilder builder)
{
    public ServiceProvider Build()
    {
        return builder.Services.AddSingleton<IDocCatcher, DocCatcher>()
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
            //.AddSingleton<ISearchAble,WordSearcher>()
            //.AddSingleton<ISearchStrategy, AdvancedStrategy>()
            .BuildServiceProvider();
    }
}