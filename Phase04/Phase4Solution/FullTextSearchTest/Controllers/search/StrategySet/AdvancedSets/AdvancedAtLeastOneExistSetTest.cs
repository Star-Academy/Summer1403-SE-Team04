using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Controllers.search.StrategySet.AdvancedSets;
using FullTextSearch.Controllers.search.StrategySet.BasicSets;
using FullTextSearch.Model;
using FullTextSearch.Model.AbstractClass;
using FullTextSearch.Model.DataStructure;
using NSubstitute;

namespace FullTextSearchTest.Controllers.search.StrategySet.AdvancedSets;

public class AdvancedAtLeastOneExistSetTest
{
    private IAdvancedFinder _advancedFinder;
    private IDocCatcher _cacher;
    private readonly AdvancedInvertedIndex _index;
    private AdvancedAtLeastOneExistsSet _sut;
    public AdvancedAtLeastOneExistSetTest()
    {
        _cacher = Substitute.For<IDocCatcher>();
        _cacher.Load().Returns(new List<Document>() { new Document("location", new List<string>() { "love","you" }) });
        Dictionary<string, List<DocumentWordStorage>> testDic = new Dictionary<string, List<DocumentWordStorage>>()
        {
            {"love", new List<DocumentWordStorage>() { new DocumentWordStorage("location", new List<int>(){0})}},
            {"you", new List<DocumentWordStorage>() { new DocumentWordStorage("location", new List<int>(){1})}}
        };
        _index = new AdvancedInvertedIndex(testDic, "location");
        _advancedFinder = new AdvancedDocFinder(_index, _cacher,new SmallWordsRemover());
    }

    [Theory]
    [InlineData(new[] { "+nonexistent phrase", "+invalid word" }, new string[] { })]
    [InlineData(new[] { "love you" }, new string[] { })]
    [InlineData(new[] { "-love you" }, new string[] { })]
    [InlineData(new string[] { }, new string[] { })]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string[] wordsArray, string[] expectedDocs)
    {
        // Arrange
        _sut = new AdvancedAtLeastOneExistsSet(wordsArray, _advancedFinder);

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
        _sut = new AdvancedAtLeastOneExistsSet(wordsArray,_advancedFinder);
        var expected = new List<string>() { "location" };
        // Act
        var actual = _sut.GetValidDocs();
        // Assert
        Assert.Equal(expected, actual);
    }
}