using FullTextSearch.Controllers.Logic.StringProcessor;
namespace FullTextSearchTest.Controllers.Logic;

public class ToLowerTest
{ 
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void FixWordsFormat_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    {
        ToLower to = new ToLower();
        Assert.Empty(to.FixWordFormat(word));
    }
    [Theory]
    [InlineData("Expensive","expensive")]
    [InlineData("Dreaming","dreaming")]
    [InlineData("Died","died")]
    public void FixWordsFormat_ShouldBeRootedWord_IfNormalInput(string word,string root)
    {
        ToLower to =new ToLower();
        Assert.Equal(root,to.FixWordFormat(word));
    }
}