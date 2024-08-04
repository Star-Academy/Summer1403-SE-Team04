using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using NSubstitute;

namespace FullTextSearchTest.Controllers.Logic.DocumentsLoader;

public class WordsListFormatFixerTest
{
    private readonly IStringReformater _reformaters;

    public WordsListFormatFixerTest()
    {
        _reformaters = Substitute.For<IStringReformater>();
    }

    [Fact]
    public void EditWords_ShouldReturnValidList_IfPathIsValid()
    {   
        // Arrange 
        var actual = new List<string>
        {
            "ali", "Mahdi"
        };
        _reformaters.FixWordFormat(Arg.Any<string>()).Returns("ali");
        var expected = new List<string> { "ali", "ali" };
        // Act
        actual = actual.FixWordsList(new List<IStringReformater> { _reformaters }).ToList();
        // Assert
        Assert.Equal(expected, actual);
    }
}