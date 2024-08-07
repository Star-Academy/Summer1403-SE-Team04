using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search.SearchStrategy;

public class TargetedStrategyTest
{
    private readonly InvertedIndex _index;
    private readonly TargetedStrategy _sut;

    public TargetedStrategyTest()
    {
        Dictionary<string, List<string>> testDic = new Dictionary<string, List<string>>()
        {
            {"love", new List<string>() { "location" }}
        };
        _index = new InvertedIndex(testDic, "location");
        _sut = new TargetedStrategy(new DocFinder(_index));
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]

    public void Search_ShouldThrowException_WhereArgumentsAreInvalid(string query)
    {
 
        // Act
        var actual = () => _sut.Search(query);
        // Assert
        Assert.Throws<NullOrEmptyQueryException>(actual);
    }

    [Fact]
    public void Search_ShouldReturnEmpty_WhereQueryDoesntExist()
    {
        // Arrange
        var query = "AWordThatDoesntExist";
        // Act
        var actual = _sut.Search(query);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public void Search_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {
        // Arrange
        var query = "love";
        // Act
        var actual = _sut.Search(query);
        // Assert
        Assert.Equal(new List<string>(){"location"}, actual);
    }
}