using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Controllers.search.StrategySet.AdvancedSets;
using FullTextSearch.Controllers.search.StrategySet.BasicSets;
using FullTextSearch.Model;
using FullTextSearch.Model.AbstractClass;
using FullTextSearch.Model.DataStructure;
using NSubstitute;

namespace FullTextSearchTest.Controllers.search.StrategySet.AdvancedSets;



public class AdvancedMustNotExistSetTest
{
    private AdvancedDocFinder _advancedDocFinder;

    private IDocCatcher _cacher;
    private readonly AdvancedInvertedIndex _index;
    private AdvancedMustNotExistSet _sut;
    public AdvancedMustNotExistSetTest()
    {
        _cacher = Substitute.For<IDocCatcher>();
        _cacher.Load().Returns(new List<Document>() { new Document("location", new List<string>() { "love","you" }) });
        Dictionary<string, IEnumerable<DocInformation>> testDic = new Dictionary<string, IEnumerable<DocInformation>>()
        {
            {"love", new List<DocInformation>() { new DocumentDocsStorage("location", new List<int>(){0})}},
            {"you", new List<DocInformation>() { new DocumentDocsStorage("location", new List<int>(){1})}}
        };
        _index = new AdvancedInvertedIndex(testDic, "location");
        _advancedDocFinder = new AdvancedDocFinder(_index, _cacher,new SmallWordsRemover());
    }

    [Theory]
    [InlineData(new[] { "-nonexistent", "-invalid word" }, new string[] { })]
    [InlineData(new[] { "+love you" }, new string[] { })]
    [InlineData(new[] { "love you" }, new string[] { })]
    [InlineData(new string[] { }, new string[] { })]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string[] wordsArray, string[] expectedDocs)
    {
        // Arrange
        _sut = new AdvancedMustNotExistSet(wordsArray, _advancedDocFinder);

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
        _sut = new AdvancedMustNotExistSet(wordsArray, _advancedDocFinder);
        var expected = new List<string>() { "location" };
        // Act
        var actual = _sut.GetValidDocs();
        // Assert
        Assert.Equal(expected, actual);
    }
}