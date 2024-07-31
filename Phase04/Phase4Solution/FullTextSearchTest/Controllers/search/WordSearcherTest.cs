using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearchTest.Controllers.search;

public class WordSearcherTest
{
    private readonly WordSearcher _sut;

    public WordSearcherTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(),
            new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        var index = new InvertedIndexLoader().Load()?.Last();
        _sut = new WordSearcher(new TargetedStrategy(index));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Search_ShouldThrowException_WhenQueryIsInvalid(string query)
    {
        //Arrange
        //Act
        var result = () => _sut.Search(query);
        //Assert
        Assert.Throws<NullOrEmptyQueryException>(result);
    }
    [Fact]
    public void Search_ShouldReturnEmpty_WhenQueryDoesntExist()
    {
        //Arrange
        var query = "AWordThatDoesntExist";
        //Act
        var result = _sut.Search(query);
        //Assert
        Assert.Empty(result);
    }
    [Fact]
    public void Search_ShouldReturnList_WhereQueryIsNormal()
    {
        //Arrange
        var query = "make";
        //Act
        var result = _sut.Search(query);
        //Assert
        Assert.NotEmpty(result);
    }
}