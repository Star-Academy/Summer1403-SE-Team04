using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearchTest.Controllers.Logic.StringProcessor;

public class ToLowerTest
{
    private ToLower _toLower;
    public ToLowerTest()
    {
        _toLower = new ToLower();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void FixWordsFormat_ShouldReturnNull_IfWordIsNullOrEmpty(string word)
    {
        // Act
        var result = _toLower.FixWordFormat(word);
        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("Expensive", "expensive")]
    [InlineData("Dreaming", "dreaming")]
    [InlineData("Died", "died")]
    public void FixWordsFormat_ShouldReturnRootedWord_IfNormalInput(string word, string root)
    {
        // Act
        var actual = _toLower.FixWordFormat(word);
        // Assert
        Assert.Equal(root, actual);
    }
}