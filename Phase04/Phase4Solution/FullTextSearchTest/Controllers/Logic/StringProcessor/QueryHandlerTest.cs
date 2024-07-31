using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearchTest.Controllers.Logic.StringProcessor;

public class QueryHandlerTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SplitIntoFormattedWords_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    { var reformaters = new List<IStringReformater>
              {
                  new ToLower(), new ToRoot()
              };
        //arrange 
        //act
        Assert.Empty(word.SplitIntoFormattedWords(reformaters));
        //assert
    }

    [Fact]
    public void SplitIntoFormattedWords_ShouldBeTheWord_IfReformatersAreNullOrEmpty()
    {
        //arrange 
                var resault = new[] { "mamad", "ali", "taha" };
                var checkString ="mamad ali taha" ;
        //act
        var check = checkString.SplitIntoFormattedWords(new List<IStringReformater>());
        //assert
        Assert.Equal(resault,check);
    }

    [Theory]
    [InlineData("Expensive dreaming", "expens", "dream")]
    [InlineData("Dreaming die", "dream", "die")]
    public void SplitIntoFormattedWords_ShouldBeRootedWord_IfNormalInputAndReformatersIsRoot(params string[] result)
    {
        //arrange 
        var word = result[0];
        var outPut = new string[result.Length - 1];
        var list = new List<IStringReformater> { new ToRoot() };
        //act
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        //assert
        Assert.Equal(outPut, word.SplitIntoFormattedWords(list));
    }

    [Theory]
    [InlineData("ExpensivE dreaminG", "expensive", "dreaming")]
    [InlineData("Dreaming died", "dreaming", "died")]
    public void SplitIntoFormattedWords_ShouldBeLowerWord_IfNormalInputAndReformatersIsLower(params string[] result)
    {
        //arrange 
        var word = result[0];
        var outPut = new string[result.Length - 1];
        var list = new List<IStringReformater> { new ToLower() };
        //act
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        //assert
        Assert.Equal(outPut, word.SplitIntoFormattedWords(list));
    }

    [Theory]
    [InlineData("EXpenSive dreamIng", "expens", "dream")]
    [InlineData("DreaminG Die", "dream", "die")]
    public void SplitIntoFormattedWords_ShouldBeRootedAndLowerWord_IfNormalInputAndReformatersIsRootAndLower(
        params string[] result)
    {
        //arrange 
        var word = result[0];
        var outPut = new string[result.Length - 1];
        var list = new List<IStringReformater> { new ToRoot(), new ToLower() };
        //act
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        //assert
        Assert.Equal(outPut, word.SplitIntoFormattedWords(list));
    }
}