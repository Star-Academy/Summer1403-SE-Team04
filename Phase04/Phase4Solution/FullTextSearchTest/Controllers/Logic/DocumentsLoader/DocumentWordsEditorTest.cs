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
    public void EditWords_ShouldBeEdited_IfPathIsNormal()
    {
        //arrange 
        var check = new List<Document> { new("test", new[] { "a" }) };
        var testDoc = new List<Document>
        {
            new("test", new[] { "a" })
        };
        _stringReformater.FixWordFormat(Arg.Any<string>()).Returns("a");
        _garbageRemover.Remove(Arg.Any<IEnumerable<string>>()).Returns(new[] { "a" });
        
        //act
        testDoc = testDoc.EditWords(new List<IStringReformater> { _stringReformater }, _garbageRemover).ToList();

        //assert
        Assert.Equivalent(check, testDoc);
    }
}