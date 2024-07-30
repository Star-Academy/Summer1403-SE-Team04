using System.Diagnostics;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using NSubstitute;
using Document = FullTextSearch.Model.Document;

namespace FullTextSearchTest.Controllers.Logic.DocumentsLoader;

public class WordsListFormatFixerTest
{
    private IStringReformater _reformaters;

    public WordsListFormatFixerTest()
    {
        _reformaters = Substitute.For<IStringReformater>();
    }
    [Fact]
    public void EditWords_ShouldBeEdited_IfPathIsNormal()
    {
        List<string> test = new List<string>()
        {
            "ali", "Mahdi"
        };
        _reformaters.FixWordFormat(Arg.Any<string>()).Returns("ali");
        test = test.FixWordsList(new List<IStringReformater>() { _reformaters }).ToList();
        var check = new List<string>() {"ali","ali"};
        Assert.Equal(check,test);
    }

}