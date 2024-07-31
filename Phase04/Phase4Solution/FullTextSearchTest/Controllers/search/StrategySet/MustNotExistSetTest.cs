using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

public class MustNotExistSetTest
{
    private readonly InvertedIndex _index;

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
        var mustNotExistSet = new MustNotExistSet(wordsArray, _index);

        // Act
        var result = mustNotExistSet.GetValidDocs();

        // Assert
        Assert.Equal(expectedDocs, result);
    }

    [Theory]
    [InlineData("-love", "-expens")]
    [InlineData("-expens", "-nonexistent")]
    [InlineData("-love")]
    public void GetValidDocs_ShouldReturnNonEmpty_WhereArgumentsAreValid(params string[] wordsArray)
    {
        var mustNotExistSet = new MustNotExistSet(wordsArray, _index);

        // Act
        var result = mustNotExistSet.GetValidDocs();

        // Assert
        Assert.NotEmpty(result);
    }
}