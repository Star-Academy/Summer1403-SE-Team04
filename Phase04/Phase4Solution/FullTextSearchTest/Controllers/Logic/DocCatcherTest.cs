
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Model;

namespace FullTextSearchTest.Controllers.Logic;

public class DocCatcherTest
{
    private readonly DocCatcher _sut;

    public DocCatcherTest()
    {
        _sut = new DocCatcher();
    }
    [Fact]
    public void Write_ShouldBeTheSame_IfNullAdded()
    {
        //arrange
        var expected = new List<Document>();
        //action
        _sut.Write(null);
        var actual = _sut.Load();
        //assert
        Assert.Equivalent(expected,actual);
    }
    [Fact]
    public void Write_ShouldBeAddTheObj_IfNotNullAdded()
    {
        //arrange
        var document =  new Document("ali", new List<string>() { "mamad" });
        var expected = new List<Document>(){document};
        //action
        _sut.Write(document);
        var actual = _sut.Load();
        //assert
        Assert.Equivalent(expected,actual);
    }

    [Fact]
    public void Load_ShouldBeLoadTheObj_IfNotNullAdded()
    {
        //arrange
        var doc = new Document("ali",new []{"mahdi"});
        var expected = new List<Document>() { doc };
        //action
        _sut.Write(doc);
        var actual = _sut.Load();
        //assert
        Assert.Equivalent(expected, actual);
    }
}