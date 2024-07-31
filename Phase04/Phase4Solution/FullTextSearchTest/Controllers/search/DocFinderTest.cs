
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search;

public class DocFinderTest
{
    private readonly DocFinder _sut;
    private readonly InvertedIndex _index;

    public DocFinderTest()
    {
        
        Dictionary<string, IEnumerable<string>> testDic = new Dictionary<string, IEnumerable<string>>()
        {
            {"love", new List<string>() { "location" }}
        };
        _index = new InvertedIndex(testDic, "location");
        _sut = new DocFinder(_index);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Find_ShouldThrowsException_WhenQueryIsInvalid(string query)
    {
        //Arrange
        // Act
        var action = () => _sut.Find(query);
        // Assert
        Assert.Throws<NullOrEmptyQueryException>(action);
    }

    [Fact]
    public void Find_ShouldReturnEmpty_WhenQueryDoesntExist()
    {
        //Arrange
        var query = "AWordThatDoesntExist";
        //Act
        var result = _sut.Find(query);
        //Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void Find_ShouldReturnList_WhenQueryExists()
    {
        //Arrange
        var query = "make";
        //Act
        var result = _sut.Find(query);
        //Assert
        Assert.NotEmpty(result);
    }
    
}