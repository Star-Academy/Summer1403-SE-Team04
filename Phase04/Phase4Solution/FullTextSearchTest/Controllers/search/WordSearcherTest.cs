using FullTextSearch;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search;

public class WordSearcherTest
{
    private readonly WordSearcher _sut;

    public WordSearcherTest()
    {
        
        Dictionary<string, IEnumerable<string>> testDic = new Dictionary<string, IEnumerable<string>>()
        {
            {"love", new List<string>() { "location" }}
        };
        var index = new InvertedIndex(testDic, "location");
        _sut = new WordSearcher(new TargetedStrategy(new DocFinder(index)));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Search_ShouldThrowException_WhenQueryIsInvalid(string query)
    {
        // Arrange
        // Act
        var result = () => _sut.Search(query);
        // Assert
        Assert.Throws<NullOrEmptyQueryException>(result);
    }
    [Fact]
    public void Search_ShouldReturnEmpty_WhenQueryDoesntExist()
    {
        // Arrange
        var query = "AWordThatDoesntExist";
        // Act
        var result = _sut.Search(query);
        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public void Search_ShouldReturnList_WhereQueryIsNormal()
    {
        // Arrange
        var query = "love";
        var expected = new List<string>() { "location" };
        // Act
        var result = _sut.Search(query);
        // Assert
        Assert.Equal(expected, result);
    }
}