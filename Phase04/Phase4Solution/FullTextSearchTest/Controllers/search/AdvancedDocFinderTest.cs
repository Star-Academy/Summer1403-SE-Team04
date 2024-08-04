using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.Abstraction;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model;
using FullTextSearch.Model.AbstractClass;
using FullTextSearch.Model.DataStructure;
using NSubstitute;

namespace FullTextSearchTest.Controllers.search;

public class AdvancedDocFinderTest
{
    private readonly AdvancedDocFinder _sut;
    private readonly AdvancedInvertedIndex _index;

    public AdvancedDocFinderTest()
    {
        
        Dictionary<string, IEnumerable<DocInformation>> testDic = new Dictionary<string, IEnumerable<DocInformation>>()
        {
            {"love", new List<DocInformation>() { new DocumentDocsStorage("location", new List<int>(){0})}},
            {"you", new List<DocInformation>() { new DocumentDocsStorage("location", new List<int>(){1})}}
        };
        _index = new AdvancedInvertedIndex(testDic, "location");
        var cacher = Substitute.For<IDocCatcher>();
        cacher.Load().Returns(new List<Document>() { new Document("location", new List<string>() { "love","you" }) });
        _sut = new AdvancedDocFinder(_index, cacher);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Find_ShouldThrowsException_WhenQueryIsInvalid(string query)
    {
        // Arrange
        // Act
        var action = () => _sut.Find(query);
        // Assert
        Assert.Throws<NullOrEmptyQueryException>(action);
    }

    [Fact]
    public void Find_ShouldReturnEmpty_WhenQueryDoesntExist()
    {
        // Arrange
        var query = "A Phrase ThatDoesntExist";
        // Act
        var result = _sut.Find(query);
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void Find_ShouldReturnList_WhenQueryExists()
    {
        // Arrange
        var query = "love you";
        var expected = new List<string>() { "location" };
        // Act
        var actual = _sut.Find(query);
        // Assert
        Assert.Equal(expected, actual);
    }

}