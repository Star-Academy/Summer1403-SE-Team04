using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using NSubstitute;
using Document = FullTextSearch.Model.Document;

namespace FullTextSearchTest.Controllers.Logic.DocumentsLoader;

public class DocumentWordsEditorTest
{
    private IGarbageRemover testq;
    private IStringReformater test;

    public DocumentWordsEditorTest()
    {
        testq = Substitute.For<IGarbageRemover>();
        test = Substitute.For<IStringReformater>();
    }
    [Fact]
    public void EditWords_ShouldBeEdited_IfPathIsNormal()
    {
        List<Document> testDoc = new List<Document>()
        {
            new Document("test", new[] { "a" })
        };
        test.FixWordFormat(Arg.Any<string>()).Returns("a");
        testq.Remove(Arg.Any<IEnumerable<string>>()).Returns(new[] { "a" });
        testDoc =testDoc.EditWords(new List<IStringReformater>(){test},testq).ToList();
        var check = new List<Document>() { new Document("test", new[] { "a" }) };
        Assert.Equivalent(check,testDoc);
    }
}