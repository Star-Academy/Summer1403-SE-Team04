using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using NSubstitute;
using Document = FullTextSearch.Model.Document;

namespace FullTextSearchTest.Controllers.Logic.DocumentsLoader;

public class DocumentWordsEditorTest
{
    private readonly IStringReformater test;
    private readonly IGarbageRemover testq;

    public DocumentWordsEditorTest()
    {
        testq = Substitute.For<IGarbageRemover>();
        test = Substitute.For<IStringReformater>();
    }

    [Fact]
    public void EditWords_ShouldBeEdited_IfPathIsNormal()
    {
        var testDoc = new List<Document>
        {
            new("test", new[] { "a" })
        };
        test.FixWordFormat(Arg.Any<string>()).Returns("a");
        testq.Remove(Arg.Any<IEnumerable<string>>()).Returns(new[] { "a" });
        testDoc = testDoc.EditWords(new List<IStringReformater> { test }, testq).ToList();
        var check = new List<Document> { new("test", new[] { "a" }) };
        Assert.Equivalent(check, testDoc);
    }
}