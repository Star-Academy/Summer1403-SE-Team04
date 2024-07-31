using System.Reflection.Metadata;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.Reader.Abstraction;
using NSubstitute;
using Document = FullTextSearch.Model.Document;

namespace FullTextSearchTest.Controllers.Logic;

public class DocBuilderTest
{
    private readonly DocBuilder _docBuilder;
    private readonly ITxtReader _txtReader;

    public DocBuilderTest()
    {
        _txtReader = Substitute.For<ITxtReader>();
        _docBuilder = new DocBuilder(_txtReader);
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Build_ShouldBeNull_IfPathIsNullOrEmpty(string path)
    {
        //arrange 
        //act
        //assert
        Assert.Null(_docBuilder.Build(path));
    }

    [Fact]
    public void Build_ShouldBeNormalDoc_IfNormalInput()
    {
        //arrange 
        _txtReader.Read(Arg.Any<string>()).Returns(new []{"ali"});
        //act
        var check = _docBuilder.Build("mamad");
        var result = new Document("mamad", new[] { "ali" });
        //assert
        Assert.Equal(check,result);
    }
}