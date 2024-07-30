using FullTextSearch.Controllers.Keepers;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.search;
using FullTextSearch.Model.DataStructure;
using FullTextSearch.View.Cli;
using NSubstitute;

namespace FullTextSearchTest.Controllers.search;

public class QuerySearcherTest
{
    private QuerySearcher _sut;
    private IInvertedIndexLoader _invertedIndexLoader;
    public QuerySearcherTest()
    {
        _invertedIndexLoader = Substitute.For<IInvertedIndexLoader>();
        _invertedIndexLoader.Load().Returns(new List<InvertedIndex>());
        _sut = new QuerySearcher(_invertedIndexLoader);
    }

    [Fact]
    public void ProcessQuery_WhenCalled_CallsLoadOnInvertedIndexLoader()
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