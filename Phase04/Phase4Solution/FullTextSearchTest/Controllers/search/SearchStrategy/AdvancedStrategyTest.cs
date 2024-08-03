using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.AbstractClass;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search.SearchStrategy;

public class AdvancedStrategyTest
{
    private readonly AdvancedInvertedIndex _index;
    private readonly AdvancedStrategy _sut;

    public AdvancedStrategyTest()
    {
        Dictionary<string, IEnumerable<WordInformation>> testDic = new Dictionary<string, IEnumerable<WordInformation>>()
        {
            {"love", new List<WordInformation>() { new DocumentWordsStorage("location", new List<int>(){0})}},
            {"you", new List<WordInformation>() { new DocumentWordsStorage("location", new List<int>(){1})}}
        };
        _index = new AdvancedInvertedIndex(testDic, "location");
        _sut = new AdvancedStrategy(new AdvancedDocFinder(_index, new DocCatcher()));
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]

    public void Search_ShouldThrowException_WhereArgumentsAreInvalid(string query)
    {
        // Arrange
        // Act
        var actual = () => _sut.Search(query);
        // Assert
        Assert.Throws<NullOrEmptyQueryException>(actual);
    }

    [Fact]
    public void Search_ShouldReturnEmpty_WhereQueryDoesntExist()
    {
        // Arrange
        var query = "A Phrase That Doesnt Exist";
        // Act
        var actual = _sut.Search(query);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public void Search_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {
        // Arrange
        var query = "love you";
        // Act
        var actual = _sut.Search(query);
        // Assert
        Assert.Equal(new List<string>(){"location"}, actual);
    }
}