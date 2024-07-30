using FullTextSearch.Controllers.Logic.StringProcessor;
namespace FullTextSearchTest.Controllers.Logic;

public class ToRootTest
{ 
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void FixWordsFormat_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    {
        ToRoot to = new ToRoot();
        Assert.Empty(to.FixWordFormat(word));
    }
    [Theory]
    [InlineData("expensive","expens")]
    [InlineData("dreaming","dream")]
    [InlineData("died","die")]
    public void FixWordsFormat_ShouldBeRootedWord_IfNormalInput(string word,string root)
    {
        ToRoot to =new ToRoot();
        Assert.Equal(root,to.FixWordFormat(word));
    }
}