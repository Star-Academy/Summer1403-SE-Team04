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
    public void EditWords_ShouldBeEdited_IfPathIsNormal()
    {   
    //arrange 
    var testList = new List<string>
    {
        "ali", "Mahdi"
    };
    _reformaters.FixWordFormat(Arg.Any<string>()).Returns("ali");
    var check = new List<string> { "ali", "ali" };
    //act
    testList = testList.FixWordsList(new List<IStringReformater> { _reformaters }).ToList();
    //assert
        Assert.Equal(check, testList);
    }
}