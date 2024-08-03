using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearchTest.Controllers.Logic.StringProcessor;

public class ToRootTest
{
    private ToRoot _toRoot;

    public ToRootTest()
    {
        _toRoot = new ToRoot();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void FixWordsFormat_ShouldReturnNull_IfWordIsNullOrEmpty(string word)
    {
        // Arrange 
        // Act
        var result = _toRoot.FixWordFormat(word);
        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("+expensive", "+expens")]
    [InlineData("dreaming", "dream")]
    [InlineData("died", "die")]
    public void FixWordsFormat_ShouldReturnRootedWord_IfNormalInput(string word, string rootedWord)
    {
        // Arrange 
        // Act
        var actual = _toRoot.FixWordFormat(word);
        // Assert
        Assert.Equal(rootedWord, actual);
    }
}