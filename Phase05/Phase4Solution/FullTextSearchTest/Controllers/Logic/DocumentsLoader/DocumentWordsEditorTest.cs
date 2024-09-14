using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using NSubstitute;
using Document = FullTextSearch.Model.Document;

namespace FullTextSearchTest.Controllers.Logic.DocumentsLoader;

public class DocumentWordsEditorTest
{
    private readonly IStringReformater _stringReformater;
    private readonly IGarbageRemover _garbageRemover;

    public DocumentWordsEditorTest()
    {
        _garbageRemover = Substitute.For<IGarbageRemover>();
        _stringReformater = Substitute.For<IStringReformater>();
    }

    [Fact]
    public void EditWords_ShouldReturnValidList_IfPathIsValid()
    {
        // Arrange 
        var expected = new List<Document> { new("test", new List<string>() { "a" }) };
        var testDoc = new List<Document>
        {
            new("test", new List<string>() { "a" })
        };
        _stringReformater.FixWordFormat(Arg.Any<string>()).Returns("a");
        _garbageRemover.Remove(Arg.Any<List<string>>()).Returns(new List<string>() { "a" });
        
        // Act
        testDoc = testDoc.EditWords(new List<IStringReformater> { _stringReformater }, _garbageRemover).ToList();

        // Assert
        Assert.Equivalent(expected, testDoc);
    }
}