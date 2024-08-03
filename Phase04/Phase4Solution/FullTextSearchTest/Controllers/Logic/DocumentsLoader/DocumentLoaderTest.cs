using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using NSubstitute;
using Document = FullTextSearch.Model.Document;

namespace FullTextSearchTest.Controllers.Logic.DocumentsLoader;

public class DocumentLoaderTest
{
    private readonly IDocBuilder _docBuilder;
    private readonly DocumentLoader _sut;
    private readonly IGarbageRemover _garbageRemover;
    private TxtReader _txtReader;

    public DocumentLoaderTest()
    {
        _garbageRemover = Substitute.For<IGarbageRemover>();
        _docBuilder = Substitute.For<IDocBuilder>();
        _sut = new DocumentLoader(_docBuilder, _garbageRemover);
    }

    [Fact]
    public void LoadDocumentsList_ShouldReturnLoadedDoc_IfPathIsNormal()
    {
        // Arrange
        var testPath = "AssetTest";
        var expected = new List<Document>
        {
            new("mahdi", new[] { "ali", "alii" }), new("mahdi", new[] { "ali", "alii" })
        };
        _garbageRemover.Remove(new[] { "ali", "alii" }).Returns(new[] { "ali", "alii" });
        _docBuilder.Build(Arg.Any<string>()).Returns(new Document("mahdi", new[] { "ali", "alii" }));
        _docBuilder.Build(Arg.Any<string>()).Returns(new Document("mahdi", new[] { "ali", "alii" }));
        // Act
        var actual = _sut.LoadDocumentsList(testPath, null);
        // Assert
        Assert.Equivalent(expected,actual);
    }
}