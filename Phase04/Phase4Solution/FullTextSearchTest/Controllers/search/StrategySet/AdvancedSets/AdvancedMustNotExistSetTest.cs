using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Controllers.search.StrategySet.AdvancedSets;
using FullTextSearch.Controllers.search.StrategySet.BasicSets;
using FullTextSearch.Model.AbstractClass;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search.StrategySet.BasicSets;


public class AdvancedMustNotExistSetTest
{
    private readonly AdvancedInvertedIndex _index;
    private AdvancedMustNotExistSet _sut;
    public AdvancedMustNotExistSetTest()
    {
        Dictionary<string, IEnumerable<WordInformation>> testDic = new Dictionary<string, IEnumerable<WordInformation>>()
        {
            {"love", new List<WordInformation>() { new DocumentWordsStorage("location", new List<int>(){0})}},
            {"you", new List<WordInformation>() { new DocumentWordsStorage("location", new List<int>(){1})}}
        };
        _index = new AdvancedInvertedIndex(testDic, "location");
    }

    [Theory]
    [InlineData(new[] { "-nonexistent", "-invalid word" }, new string[] { })]
    [InlineData(new[] { "+love you" }, new string[] { })]
    [InlineData(new[] { "love you" }, new string[] { })]
    [InlineData(new string[] { }, new string[] { })]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string[] wordsArray, string[] expectedDocs)
    {
        // Arrange
        _sut = new AdvancedMustNotExistSet(wordsArray, _index);

        // Act
        var result = _sut.GetValidDocs();

        // Assert
        Assert.Equal(expectedDocs, result);
    }
    [Fact]
    public void GetValidDocs_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {
        // Arrange
        var wordsArray = new string[] { "-love you" };
        _sut = new AdvancedMustNotExistSet(wordsArray, _index);
        var expected = new List<string>() { "location" };
        // Act
        var actual = _sut.GetValidDocs();
        // Assert
        Assert.Equal(expected, actual);
    }
}