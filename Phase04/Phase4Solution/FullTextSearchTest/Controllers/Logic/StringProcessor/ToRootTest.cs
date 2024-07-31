using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearchTest.Controllers.Logic.StringProcessor;

public class ToRootTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void FixWordsFormat_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    {
        var to = new ToRoot();
        Assert.Empty(to.FixWordFormat(word));
    }

    [Theory]
    [InlineData("expensive", "expens")]
    [InlineData("dreaming", "dream")]
    [InlineData("died", "die")]
    public void FixWordsFormat_ShouldBeRootedWord_IfNormalInput(string word, string root)
    {
        var to = new ToRoot();
        Assert.Equal(root, to.FixWordFormat(word));
    }
}