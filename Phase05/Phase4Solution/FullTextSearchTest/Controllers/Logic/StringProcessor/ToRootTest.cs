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
        // Act
        var result = _toRoot.FixWordFormat(word);
        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("+expensive dreaming", "+expens dream")]
    [InlineData("dreaming", "dream")]
    [InlineData("need", "die")]
    public void FixWordsFormat_ShouldReturnRootedWord_IfNormalInput(string word, string rootedWord)
    {
  
        // Act
        var actual = _toRoot.FixWordFormat(word);
        // Assert
        Assert.Equal(rootedWord, actual);
    }
}