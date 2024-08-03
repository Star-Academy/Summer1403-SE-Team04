using FullTextSearch.Controllers.Logic.Creator_Loader;

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
        var expected = _sut.;
        //action
        _sut.Write(null);
        var actual = _sut.AdvanceInvertedIndices;
        //assert
        Assert.Equivalent(expected,actual);
    }
    [Fact]
    public void Write_ShouldBeAddTheObj_IfNotNullAdded()
    {
        //arrange
        var docList = new List<Document>() { new Document("ali", new List<string>() { "mamad" }) };
        var advInvert = new AdvancedInvertedIndex(docList, "mahdi");
        var expected = new List<AdvancedInvertedIndex>(){advInvert};
        //action
        _sut.Write(advInvert);
        var actual = _sut.AdvanceInvertedIndices;
        //assert
        Assert.Equivalent(expected,actual);
    }

    [Fact]
    public void Load_ShouldBeLoadTheObj_IfNotNullAdded()
    {
        //arrange
        var docList = new List<Document>() { new Document("ali", new List<string>() { "mamad" }) };
        var advInvert = new AdvancedInvertedIndex(docList, "mahdi");
        var expected = new List<AdvancedInvertedIndex>() { advInvert };
        //action
        _sut.AdvanceInvertedIndices.Add(advInvert);
        var actual = _sut.Load();
        //assert
        Assert.Equivalent(expected, actual);
    }
}