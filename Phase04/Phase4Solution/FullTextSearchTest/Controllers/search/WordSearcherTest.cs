using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.SearchStrategy;

namespace FullTextSearchTest.Controllers.search;

public class WordSearcherTest
{
    private readonly WordSearcher _sut;

    public WordSearcherTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(),
            new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        var index = new InvertedIndexLoader().Load().Last();
        _sut = new WordSearcher(new TargetedStrategy(index));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("JustARandomWord")]
    public void Search_ShouldReturnEmpty_WhereQueryIsInvalid(string query)
    {
        Assert.Empty(_sut.Search(query));
    }

    [Theory]
    [InlineData("make")]
    [InlineData("love")]
    [InlineData("dream")]
    public void Search_ShouldReturnList_WhereQueryIsNormal(string query)
    {
        Assert.NotEmpty(_sut.Search(query));
    }
}