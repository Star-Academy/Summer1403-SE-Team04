using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Model.DataStructure;
using FullTextSearch.View.Cli;
using NSubstitute;

namespace FullTextSearchTest.Controllers.search;

public class AdvancedQuerySearcherTest
{
    
    private readonly IAdvancedInvertedIndexCatcher _invertedIndexLoader;
    private readonly AdvancedQuerySearcher _sut;

    public AdvancedQuerySearcherTest()
    {
        _invertedIndexLoader = Substitute.For<IAdvancedInvertedIndexCatcher>();
        _invertedIndexLoader.Load().Returns(new List<AdvancedInvertedIndex>());
        _sut = new AdvancedQuerySearcher(_invertedIndexLoader,new DocCatcher());
    }

    [Fact]
    public void ProcessQuery_ShouldCallLoadOnInvertedIndexLoader_WhenCalled()
    {
        // Arrange
        var query = "test query";
        OutputRendererKeeper.Instance.OutputRenderer = new OutputPrinter();
        // Act
        _sut.ProcessQuery(query);
        // Assert
        _invertedIndexLoader.Received(1).Load();
    }
}