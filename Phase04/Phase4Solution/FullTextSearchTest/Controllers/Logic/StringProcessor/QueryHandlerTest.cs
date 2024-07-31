using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearchTest.Controllers.Logic.StringProcessor;

public class QueryHandlerTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SplitIntoFormattedWords_ShouldBeNull_IfWordIsNullOrEmpty(string word)
    {
        var reformaters = new List<IStringReformater>
        {
            new ToLower(), new ToRoot()
        };
        Assert.Empty(word.SplitIntoFormattedWords(reformaters));
    }

    [Fact]
    public void SplitIntoFormattedWords_ShouldBeTheWord_IfReformatersAreNullOrEmpty()
    {
        Assert.Equal(new[] { "mamad", "ali", "taha" },
            "mamad ali taha".SplitIntoFormattedWords(new List<IStringReformater>()));
    }

    [Theory]
    [InlineData("Expensive dreaming", "expens", "dream")]
    [InlineData("Dreaming die", "dream", "die")]
    public void SplitIntoFormattedWords_ShouldBeRootedWord_IfNormalInputAndReformatersIsRoot(params string[] result)
    {
        var word = result[0];
        var outPut = new string[result.Length - 1];
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        var list = new List<IStringReformater> { new ToRoot() };
        Assert.Equal(outPut, word.SplitIntoFormattedWords(list));
    }

    [Theory]
    [InlineData("ExpensivE dreaminG", "expensive", "dreaming")]
    [InlineData("Dreaming died", "dreaming", "died")]
    public void SplitIntoFormattedWords_ShouldBeLowerWord_IfNormalInputAndReformatersIsLower(params string[] result)
    {
        var word = result[0];
        var outPut = new string[result.Length - 1];
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        var list = new List<IStringReformater> { new ToLower() };
        Assert.Equal(outPut, word.SplitIntoFormattedWords(list));
    }

    [Theory]
    [InlineData("EXpenSive dreamIng", "expens", "dream")]
    [InlineData("DreaminG Die", "dream", "die")]
    public void SplitIntoFormattedWords_ShouldBeRootedAndLowerWord_IfNormalInputAndReformatersIsRootAndLower(
        params string[] result)
    {
        var word = result[0];
        var outPut = new string[result.Length - 1];
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        var list = new List<IStringReformater> { new ToRoot(), new ToLower() };
        Assert.Equal(outPut, word.SplitIntoFormattedWords(list));
    }
}