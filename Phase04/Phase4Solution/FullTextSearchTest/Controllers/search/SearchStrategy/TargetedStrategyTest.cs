using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search.SearchStrategy;
using FullTextSearch.Model.DataStructure;

public class TargetedStrategyTest
{
    private readonly InvertedIndex _index;
    private readonly TargetedStrategy _sut;

    public TargetedStrategyTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(),
            new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        _index = new InvertedIndexLoader().Load()?.Last();
        _sut = new TargetedStrategy(_index);
    }


    [Theory]
    [InlineData("nonexistent")]
    [InlineData("invalidword")]
    [InlineData(null)]
    [InlineData("")]
    public void GetValidDocs_ShouldReturnEmpty_WhereArgumentsAreInvalid(string query)
    {
        var result = _sut.Search(query);
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("love")]
    [InlineData("dream")]
    [InlineData("make")]
    public void GetValidDocs_ShouldReturnNonEmpty_WhereArgumentsAreValid(string query)
    {
        var result = _sut.Search(query);
        Assert.NotEmpty(result);
    }
}