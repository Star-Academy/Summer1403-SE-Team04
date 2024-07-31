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
    public void FixWordsFormat_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    {
        //arrange 
        //act
        //assert
        Assert.Empty(_toLower.FixWordFormat(word));
    }

    [Theory]
    [InlineData("Expensive", "expensive")]
    [InlineData("Dreaming", "dreaming")]
    [InlineData("Died", "died")]
    public void FixWordsFormat_ShouldBeRootedWord_IfNormalInput(string word, string root)
    {
        //arrange 
        //act
        //assert
        Assert.Equal(root, _toLower.FixWordFormat(word));
    }
}