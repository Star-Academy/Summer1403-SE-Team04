using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Creator_Loader;
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
        _docBuilder = new DocBuilder(_txtReader , new DocCatcher());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Build_ShouldReturnNull_IfPathIsNullOrEmpty(string path)
    {
        // Arrange 
        // Act
        var result = _docBuilder.Build(path);
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Build_ShouldReturnNormalDoc_IfNormalInput()
    {
        // Arrange 
        _txtReader.Read("mamad").Returns(new List<string>() { "ali" });
        var expected = new Document("mamad", new List<string>() { "ali" });
        // Act
        var actual = _docBuilder.Build("mamad");
        // Assert
        Assert.Equal(expected, actual);
    }
}