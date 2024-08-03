using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search.StrategySet;

public class MustExistSetTest
{
    private readonly InvertedIndex _index;
    private MustExistSet _sut;
    public MustExistSetTest()
    {
        
        Dictionary<string, IEnumerable<string>> testDic = new Dictionary<string, IEnumerable<string>>()
        {
            {"love", new List<string>() { "location" }}
        };
        _index = new InvertedIndex(testDic, "location");
    }

    [Theory]
    [InlineData(new[] { "nonexistent", "invalidword" }, new string[] { })]
    [InlineData(new[] { "+love" }, new string[] { })]
    [InlineData(new[] { "-love" }, new string[] { })]
    [InlineData(new string[] { }, new string[] { })]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string[] wordsArray, string[] expectedDocs)
    {
        // Arrange
        _sut = new MustExistSet(wordsArray, _index);

        // Act
        var result = _sut.GetValidDocs();

        // Assert
        Assert.Equal(expectedDocs, result);
    }
    [Fact]
    public void GetValidDocs_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {
        // Arrange
        var wordsArray = new string[] { "love" };
        _sut = new MustExistSet(wordsArray, _index);
        var expected = new List<string>() { "location" };
        // Act
        var actual = _sut.GetValidDocs();

        // Assert
        Assert.Equal(expected, actual);
    }
}