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
    public void FixWordsFormat_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    {
        //arrange 
        //act
        //assert
        Assert.Empty(_toRoot.FixWordFormat(word));
    }

    [Theory]
    [InlineData("expensive", "expens")]
    [InlineData("dreaming", "dream")]
    [InlineData("died", "die")]
    public void FixWordsFormat_ShouldBeRootedWord_IfNormalInput(string word, string rootedWord)
    {
        //arrange 
        //act
        //assert
        Assert.Equal(rootedWord, _toRoot.FixWordFormat(word));
    }
}