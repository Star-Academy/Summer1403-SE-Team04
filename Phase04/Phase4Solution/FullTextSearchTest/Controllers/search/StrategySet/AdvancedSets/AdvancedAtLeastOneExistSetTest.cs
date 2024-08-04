using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Controllers.search.StrategySet.AdvancedSets;
using FullTextSearch.Controllers.search.StrategySet.BasicSets;
using FullTextSearch.Model.AbstractClass;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search.StrategySet.AdvancedSets;

public class AdvancedAtLeastOneExistSetTest
{
    private readonly AdvancedInvertedIndex _index;
    private AdvancedAtLeastOneExistsSet _sut;
    public AdvancedAtLeastOneExistSetTest()
    {
        Dictionary<string, IEnumerable<DocInformation>> testDic = new Dictionary<string, IEnumerable<DocInformation>>()
        {
            {"love", new List<DocInformation>() { new DocumentDocsStorage("location", new List<int>(){0})}},
            {"you", new List<DocInformation>() { new DocumentDocsStorage("location", new List<int>(){1})}}
        };
        _index = new AdvancedInvertedIndex(testDic, "location");
    }

    [Theory]
    [InlineData(new[] { "+nonexistent phrase", "+invalid word" }, new string[] { })]
    [InlineData(new[] { "love you" }, new string[] { })]
    [InlineData(new[] { "-love you" }, new string[] { })]
    [InlineData(new string[] { }, new string[] { })]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string[] wordsArray, string[] expectedDocs)
    {
        // Arrange
        _sut = new AdvancedAtLeastOneExistsSet(wordsArray, new AdvancedDocFinder(_index, new DocCatcher()));

        // Act
        var result = _sut.GetValidDocs();

        // Assert
        Assert.Equal(expectedDocs, result);
    }

    [Fact]
    public void GetValidDocs_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {   
        // Arrange
        var wordsArray = new string[] { "+love you" };
        _sut = new AdvancedAtLeastOneExistsSet(wordsArray, new AdvancedDocFinder(_index, new DocCatcher()));
        var expected = new List<string>() { "location" };
        // Act
        var actual = _sut.GetValidDocs();
        // Assert
        Assert.Equal(expected, actual);
    }
}