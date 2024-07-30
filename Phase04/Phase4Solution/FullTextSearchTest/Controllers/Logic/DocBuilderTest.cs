using System.Diagnostics.CodeAnalysis;
using static FullTextSearch.Controllers.Logic.MathHelper;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Model;

namespace FullTextSearchTest.Controllers.Logic;

public class DocBuilderTest
{ 
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Build_ShouldBeNull_IfPathIsNullOrEmpty(string path)
    {
        DocBuilder docBuilder = new DocBuilder(new TxtReader());
        Assert.Null(docBuilder.Build(path));
    }
    [Fact]
    public void Build_ShouldBeNormalDoc_IfNormalInput()
    {
        DocBuilder docBuilder = new DocBuilder(new TxtReader());
        //todo
    }
}