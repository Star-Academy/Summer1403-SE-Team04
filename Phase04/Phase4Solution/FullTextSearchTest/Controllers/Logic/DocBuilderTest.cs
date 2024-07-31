using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader;

namespace FullTextSearchTest.Controllers.Logic;

public class DocBuilderTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Build_ShouldBeNull_IfPathIsNullOrEmpty(string path)
    {
        var docBuilder = new DocBuilder(new TxtReader());
        Assert.Null(docBuilder.Build(path));
    }

    [Fact]
    public void Build_ShouldBeNormalDoc_IfNormalInput()
    {
        var docBuilder = new DocBuilder(new TxtReader());
        //todo
    }
}