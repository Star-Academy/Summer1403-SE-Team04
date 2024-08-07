using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.StringProcessor;

namespace FullTextSearchTest.Controllers.Logic.StringProcessor;

public class QueryHandlerTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SplitIntoFormattedWords_ShouldReturnNull_IfWordIsNullOrEmpty(string word)
    {
        var reformaters = new List<IStringReformater>
        {
            new ToLower(), new ToRoot()
        };
        // Act
        var result = word.SplitIntoFormattedWords(reformaters);
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SplitIntoFormattedWords_ShouldReturnTheWord_IfReformatersAreNullOrEmpty()
    {
        // Arrange 
        var expected = new[] { "mamad", "ali", "taha" };
        var actualString = "mamad ali taha";
        // Act
        var actual = actualString.SplitIntoFormattedWords(new List<IStringReformater>());
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Expensive dreaming", "expens", "dream")]
    [InlineData("Dreaming die", "dream", "die")]
    public void SplitIntoFormattedWords_ShouldReturnRootedWord_IfNormalInputAndReformatersIsRoot(params string[] result)
    {
        // Arrange 
        var word = result[0];
        var outPut = new string[result.Length - 1];
        var list = new List<IStringReformater> { new ToRoot() };
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        // Act
        var actual = word.SplitIntoFormattedWords(list);
        // Assert
        Assert.Equal(outPut, actual);
    }

    [Theory]
    [InlineData("ExpensivE dreaminG", "expensive", "dreaming")]
    [InlineData("Dreaming died", "dreaming", "died")]
    public void SplitIntoFormattedWords_ShouldReturnLowerWord_IfNormalInputAndReformatersIsLower(params string[] result)
    {
        // Arrange 
        var word = result[0];
        var outPut = new string[result.Length - 1];
        var list = new List<IStringReformater> { new ToLower() };
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        // Act
        var actual = word.SplitIntoFormattedWords(list);
        // Assert
        Assert.Equal(outPut, actual);
    }

    [Theory]
    [InlineData("EXpenSive dreamIng", "expens", "dream")]
    [InlineData("DreaminG Die", "dream", "die")]
    public void SplitIntoFormattedWords_ShouldReturnRootedAndLowerWord_IfNormalInputAndReformatersIsRootAndLower(
        params string[] result)
    {
        // Arrange 
        var word = result[0];
        var outPut = new string[result.Length - 1];
        var list = new List<IStringReformater> { new ToRoot(), new ToLower() };
        for (var i = 0; i < outPut.Length; i++) outPut[i] = result[i + 1];
        // Act
        var actual = word.SplitIntoFormattedWords(list);
        // Assert
        Assert.Equal(outPut, actual);
    }
}