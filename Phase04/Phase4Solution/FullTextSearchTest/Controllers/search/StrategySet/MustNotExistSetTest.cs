using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

public class MustNotExistSetTest
{
    private readonly InvertedIndex _index;
    private MustNotExistSet _sut;
    public MustNotExistSetTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(),
            new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        _index = new InvertedIndexLoader().Load()?.Last();
    }

    [Theory]
    [InlineData(new[] { "-nonexistent", "-invalidword" }, new string[] { })]
    [InlineData(new string[] { }, new string[] { })]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string[] wordsArray, string[] expectedDocs)
    {
        // Arrange
        _sut = new MustNotExistSet(wordsArray, _index);

        // Act
        var result = _sut.GetValidDocs();

        // Assert
        Assert.Equal(expectedDocs, result);
    }
    [Fact]
    public void GetValidDocs_ShouldReturnNonEmpty_WhereArgumentsAreValid()
    {
        // Arrange
        var wordsArray = new string[] { "-love" };
        _sut = new MustNotExistSet(wordsArray, _index);
        // Act
        var result = _sut.GetValidDocs();
        // Assert
        Assert.NotEmpty(result);
    }
}