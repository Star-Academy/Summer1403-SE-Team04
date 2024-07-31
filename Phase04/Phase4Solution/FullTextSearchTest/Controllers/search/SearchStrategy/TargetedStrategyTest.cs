using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

public class TargetedStrategyTest
{
    private readonly InvertedIndex _index;
    private readonly TargetedStrategy _sut;

    public TargetedStrategyTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(),
            new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        _index = new InvertedIndexLoader().Load()?.Last();
        _sut = new TargetedStrategy(_index);
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]

    public void Search_ShouldThrowException_WhereArgumentsAreInvalid(string query)
    {
        // Arrange
        // Act
        var result = () => _sut.Search(query);
        // Assert
        Assert.Throws<NullOrEmptyQueryException>(result);
    }

    [Fact]
    public void Search_ShouldReturnEmpty_WhereQueryDoesntExist()
    {
        // Arrange
        var query = "AWordThatDoesntExist";
        // Act
        var result = _sut.Search(query);
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Search_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {
        // Arrange
        var query = "love";
        // Act
        var result = _sut.Search(query);
        // Assert
        Assert.NotEmpty(result);
    }
}